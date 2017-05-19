using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class CameraControler : MonoBehaviour {

    public Image foto;
    public Text tirarFoto;
    public Text ok;
    public InputField input_name;
    public bool mandaVer;

    // Opcoes
    public int dificuldade;
    public Outline diff1;
    public Outline diff2;

    WebCamTexture webCamTexture;

	// Use this for initialization
	void Start () {

        dificuldade = 1;

        ok.color = Color.gray;
        mandaVer = false;

        var devices = WebCamTexture.devices;
        bool findOne = false;

        for(int i = 0 ; i < devices.Length; i++)
        {
            if(devices[i].isFrontFacing)
            {
                webCamTexture = new WebCamTexture(devices[i].name);
                findOne = true;
                break;
            }
        }
            
        if(!findOne)
        {
            webCamTexture = new WebCamTexture();
        }

        if(webCamTexture == null)
        {
            Debug.Log("Could not create webcam texture");
        }
//        foto.material.mainTexture = webCamTexture;
        webCamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(webCamTexture.isPlaying)
        {
            Texture2D text = new Texture2D(webCamTexture.width, webCamTexture.height);
            text.SetPixels(webCamTexture.GetPixels());
            text.Apply();

            var origin = new Vector2(text.width*0.2f, 0);
            var size = new Vector2(text.width * 0.6f, text.height);

            var rect = new Rect(origin, size);

            Destroy(foto.sprite);

            foto.sprite = Sprite.Create(text, rect, new Vector2(0.5f, 0.5f));    
        }

        diff1.enabled = dificuldade == 1;
        diff2.enabled = dificuldade == 2;

        if(input_name.text != "" && mandaVer)
        {
            ok.color = Color.white;
        } else 
        {
            ok.color = Color.gray;
        }
	}

    public void OK()
    {
        if(input_name.text != "" && mandaVer)
        {
            // TODO: go to nextscene
            PlayerPrefs.SetString("nome_jogador", input_name.text);
            PlayerPrefs.Save();
            Application.LoadLevel("cena_tuto");
        }
    }

    public void Tira()
    {
        if(mandaVer)
        {
            TirarOutra();
        } else {
            TirarFoto();
        }
    }

    public void TirarFoto()
    {
        webCamTexture.Stop();
        mandaVer = true;
        tirarFoto.text = "Tirar Outra";

        var res = foto.sprite.texture.EncodeToJPG();
        string enc = Convert.ToBase64String(res);

        PlayerPrefs.SetString("foto_jogador", enc);
        PlayerPrefs.Save();
    }

    [ContextMenu("Load FOto")]
    public void LoadFoto()
    {
        webCamTexture.Stop();

        var b64_string = PlayerPrefs.GetString("foto_jogador");
        var b64_bytes = System.Convert.FromBase64String(b64_string);
        var text = new Texture2D(2,2);
        text.LoadImage( b64_bytes);

        var origin = new Vector2(text.width*0.2f, 0);
        var size = new Vector2(text.width * 0.6f, text.height);

        var rect = new Rect(origin, size);

        foto.sprite = Sprite.Create(text, rect, new Vector2(0.5f, 0.5f));
    }
        

    public void TirarOutra()
    {
        tirarFoto.text = "Tirar Foto";
        mandaVer = false;
        webCamTexture.Play();
    }

    public void ChangeDificuldade(int dificuldade)
    {
        this.dificuldade = dificuldade;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Animator anim;

    public Text score1;
    public Text score2;
    public Text score3;

    public Image foto1;
    public Image foto2;
    public Image foto3;

    public Text nome1;
    public Text nome2;
    public Text nome3;

	// Use this for initialization
	void Start () {
        LoadScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Idle()
    {
        anim.SetTrigger("Idle");
    }

    public void Ranking()
    {
        anim.SetTrigger("Ranking");
    }

    public void Credits()
    {
        anim.SetTrigger("Credits");
    }

    public void Jogo()
    {
        anim.SetTrigger("Jogo");
    }

    public void ResetScore()
    {
        PlayerPrefs.SetString("nome_1", "Eliminado");
        PlayerPrefs.SetString("nome_2", "Eliminado");
        PlayerPrefs.SetString("nome_3", "Eliminado");

        PlayerPrefs.SetInt("score_1", 0);
        PlayerPrefs.SetInt("score_2", 0);
        PlayerPrefs.SetInt("score_3", 0);

        PlayerPrefs.SetString("foto_1", "/");
        PlayerPrefs.SetString("foto_2", "/");
        PlayerPrefs.SetString("foto_3", "/");

        PlayerPrefs.Save();

        LoadScore();
    }

    public void LoadScore()
    {
        nome1.text = PlayerPrefs.GetString("nome_1");
        nome2.text = PlayerPrefs.GetString("nome_2");
        nome3.text = PlayerPrefs.GetString("nome_3");

        var score_1 = PlayerPrefs.GetInt("score_1");
        var score_2 = PlayerPrefs.GetInt("score_2");
        var score_3 = PlayerPrefs.GetInt("score_3");

        if(score_1 == 0)
        {
            score1.text = "00:00";
        } 
        else
        {
            int intSec = score_1;
            int seconds = intSec % 60; 
            int minutes = (intSec / 60) % 60; 

            score1.text = string.Format("{0}:{1}", minutes, seconds);
        }


        if(score_2 == 0)
        {
            score2.text = "00:00";
        } 
        else
        {
            int intSec = score_2;
            int seconds = intSec % 60; 
            int minutes = (intSec / 60) % 60; 

            score2.text = string.Format("{0}:{1}", minutes, seconds);
        }

        if(score_3 == 0)
        {
            score3.text = "00:00";
        } 
        else
        {
            int intSec = score_3;
            int seconds = intSec % 60; 
            int minutes = (intSec / 60) % 60; 

            score3.text = string.Format("{0}:{1}", minutes, seconds);
        }

        string foto_1 = PlayerPrefs.GetString("foto_1");
        string foto_2 = PlayerPrefs.GetString("foto_2");
        string foto_3 = PlayerPrefs.GetString("foto_3");

        if(foto_1 == "/")
        {
            foto1.color = Color.black;
        }
        else
        {
            var b64_bytes = System.Convert.FromBase64String(foto_1);
            var text = new Texture2D(2,2);
            text.LoadImage( b64_bytes);

            var origin = new Vector2(text.width*0.2f, 0);
            var size = new Vector2(text.width * 0.6f, text.height);

            var rect = new Rect(origin, size);

            foto1.sprite = Sprite.Create(text, rect, new Vector2(0.5f, 0.5f));
        }

        if(foto_2 == "/")
        {
            foto2.color = Color.black;
        }
        else
        {
            var b64_bytes = System.Convert.FromBase64String(foto_2);
            var text = new Texture2D(2,2);
            text.LoadImage( b64_bytes);

            var origin = new Vector2(text.width*0.2f, 0);
            var size = new Vector2(text.width * 0.6f, text.height);

            var rect = new Rect(origin, size);

            foto2.sprite = Sprite.Create(text, rect, new Vector2(0.5f, 0.5f));
        }

        if(foto_3 == "/")
        {
            foto3.color = Color.black;
        }
        else
        {
            var b64_bytes = System.Convert.FromBase64String(foto_3);
            var text = new Texture2D(2,2);
            text.LoadImage( b64_bytes);

            var origin = new Vector2(text.width*0.2f, 0);
            var size = new Vector2(text.width * 0.6f, text.height);

            var rect = new Rect(origin, size);

            foto3.sprite = Sprite.Create(text, rect, new Vector2(0.5f, 0.5f));
        }

    }
}

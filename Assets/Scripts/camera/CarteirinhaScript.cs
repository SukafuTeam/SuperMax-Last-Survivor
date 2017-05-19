using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CarteirinhaScript : MonoBehaviour {

    public Image foto;
    public Text nome;

	// Use this for initialization
	void Start () {
        var b64_string = PlayerPrefs.GetString("foto_jogador");
        var b64_bytes = System.Convert.FromBase64String(b64_string);
        var text = new Texture2D(2,2);
        text.LoadImage( b64_bytes);

        var origin = new Vector2(text.width*0.2f, 0);
        var size = new Vector2(text.width * 0.6f, text.height);

        var rect = new Rect(origin, size);

        foto.sprite = Sprite.Create(text, rect, new Vector2(0.5f, 0.5f));

        nome.text = PlayerPrefs.GetString("nome_jogador");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

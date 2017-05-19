using UnityEngine;
using UnityEngine.UI;

public class GetVictoryMessage : MonoBehaviour {

    public Text txt;

	// Use this for initialization
	void Start () {
        txt.text = PlayerPrefs.GetString("victory");

        var nome = PlayerPrefs.GetString("nome_jogador");
        var foto = PlayerPrefs.GetString("foto_jogador");
        var score = PlayerPrefs.GetInt("pontos_jogador");

        var nome_1 = PlayerPrefs.GetString("nome_1");
        var nome_2 = PlayerPrefs.GetString("nome_2");
        var nome_3 = PlayerPrefs.GetString("nome_3");

        var score_1 = PlayerPrefs.GetInt("score_1");
        var score_2 = PlayerPrefs.GetInt("score_2");
        var score_3 = PlayerPrefs.GetInt("score_3");

        string foto_1 = PlayerPrefs.GetString("foto_1");
        string foto_2 = PlayerPrefs.GetString("foto_2");
        string foto_3 = PlayerPrefs.GetString("foto_3");

        if(score < score_1 || score_1 == 0)
        {
            score_3 = score_2;
            nome_3 = nome_2;
            foto_3 = foto_2;

            score_2 = score_1;
            nome_2 = nome_1;
            foto_2 = foto_1;

            score_1 = score;
            nome_1 = nome;
            foto_1 = foto;
        } else if(score < score_2 || score_2 == 0)
        {
            score_3 = score_2;
            nome_3 = nome_2;
            foto_3 = foto_2;

            score_2 = score;
            nome_2 = nome;
            foto_2 = foto;
        } else if(score < score_3 || score_3 == 0)
        {
            score_3 = score;
            nome_3 = nome;
            foto_3 = foto;
        }

        PlayerPrefs.SetInt("score_1", score_1);
        PlayerPrefs.SetInt("score_2", score_2);
        PlayerPrefs.SetInt("score_3", score_3);

        PlayerPrefs.SetString("nome_1", nome_1);
        PlayerPrefs.SetString("nome_2", nome_2);
        PlayerPrefs.SetString("nome_3", nome_3);

        PlayerPrefs.SetString("foto_1", foto_1);
        PlayerPrefs.SetString("foto_2", foto_2);
        PlayerPrefs.SetString("foto_3", foto_3);

        PlayerPrefs.Save();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

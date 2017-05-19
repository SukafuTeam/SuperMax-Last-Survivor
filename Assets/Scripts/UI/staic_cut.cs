using UnityEngine;
using UnityEngine.UI;

public class staic_cut : MonoBehaviour {

    public Image noise;
    public AudioSource src;
    public float timeOn;

    public float time1;
    public float time2;
    public float time3;

    public Image globo;
    public Image bgs;

	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if(!PlayerPrefs.HasKey("score_1"))
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
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(timeOn > 0)
        {
            timeOn -= Time.deltaTime;
        } else {
            noise.enabled = false;
        }

        if(time1 > 0)
        {
            time1 -= Time.deltaTime;
            if(time1 <= 0)
            {
                Static();
                globo.enabled = true;
            }
        }
        if(time2 > 0)
        {
            time2 -= Time.deltaTime;
            if(time2 <= 0)
            {
                Static();
                globo.enabled = false;
                bgs.enabled = true;
            }
        }
        if(time3 > 0)
        {
            time3 -= Time.deltaTime;
            if(time3 <= 0)
            {
                Static(false);
            }
        }
	}

    [ContextMenu("Static")]
    public void Static(bool sound = true)
    {
        timeOn = 0.7f;
        noise.enabled = true;
        if(sound)
            src.Play();
    }
}

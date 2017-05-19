using UnityEngine;
using UnityEngine.UI;

public class SustinhoScript : MonoBehaviour {

    public float timetobegin;
    public float timetogameover;
    public Image statico;
    public Image monxtro;
    bool started;
    AudioSource src;
    public AudioSource grito_src;

	// Use this for initialization
	void Start () {
        SoundData.Stop();
        started = false;
        src = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        timetobegin -= Time.deltaTime;
        if(timetobegin <= 0 && !started)
        {
            started = true;
            statico.enabled = true;
            monxtro.enabled = true;
            src.Play();
            grito_src.Play();
        }
        if(timetogameover > 0)
        {
            timetogameover -= Time.deltaTime;
            if(timetogameover <= 0)
            {
                monxtro.enabled = false;
                statico.enabled = false;
                src.Stop();
                Application.LoadLevel("cena_menu");
            }
        }
	}
}

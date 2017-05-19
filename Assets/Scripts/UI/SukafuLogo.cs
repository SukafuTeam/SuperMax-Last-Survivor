using UnityEngine;
using UnityEngine.UI;

public class SukafuLogo : MonoBehaviour {

    public float timeInicial;
    public float timeShow;
    public float timeDesapear;
    public int state;

    public float actualTime;

    public AudioClip sound;
    public bool show = false;

    //parte especifica 
    public GameObject jogo_logo;

	// Use this for initialization
	void Start () {
        state = 0;
        actualTime = timeInicial;
	}
	
	// Update is called once per frame
	void Update () {
        if(state == 0)
        {
            actualTime -= Time.deltaTime;
            if(actualTime <= 0)
            {
                HoraDoShow();
            }
        } 
        else if(state == 1)
        {
            Color col = this.gameObject.GetComponent<Image>().color;

            if(col.a < 1)
                col.a += 0.05f;

            this.gameObject.GetComponent<Image>().color = col;

            actualTime -= Time.deltaTime;
            if(actualTime <= 0)
            {
                show = false;
                actualTime = timeDesapear;
                state = 2;
            }
        }
        else
        {
            Color col = this.gameObject.GetComponent<Image>().color;

            if(col.a > 0)
                col.a -= 0.05f;

            this.gameObject.GetComponent<Image>().color = col;

            actualTime -= Time.deltaTime;
            if(actualTime <= 0)
            {

                // parte especifica
                Application.LoadLevel("cena_menu");

                Destroy(this.gameObject);
            }
        }
	}

    void HoraDoShow()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
        show = true;
        actualTime = timeShow;
        state = 1;
    }
}

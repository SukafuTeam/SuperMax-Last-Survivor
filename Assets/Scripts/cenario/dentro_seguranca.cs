using UnityEngine;
using System.Collections;

public class dentro_seguranca : MonoBehaviour {

    public int stado;
    public Sprite sprite1;
    public Sprite sprite2;

    public float timetoupdate;

	// Use this for initialization
	void Start () {
        stado = 1;
        timetoupdate = Random.Range(0.3f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
        timetoupdate -= Time.deltaTime;
        if(timetoupdate <= 0)
        {
            timetoupdate = Random.Range(0.3f, 0.7f);
            if(stado == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
                stado = 2;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
                stado = 1;
            }
        }
	}
}

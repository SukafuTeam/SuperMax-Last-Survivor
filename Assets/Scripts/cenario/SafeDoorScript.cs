using UnityEngine;
using System.Collections;

public class SafeDoorScript : MonoBehaviour {

    public bool hasRadio;

    public GameObject radio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open()
    {
        if(Vector2.Distance(this.gameObject.transform.position, Game.Data.player.transform.position) < 2)
        {
            Game.Data.filtro.SetActive(false);
            Game.Data.nevoa.SetActive(false);

            Game.Data.returnPlace = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.5f, this.gameObject.transform.position.z);
            Game.Data.player.transform.position = new Vector3(-120,-2.4f,0);

//            if(hasRadio && !Game.Data.itens[1][2])
//            {
//                Instantiate(radio, new Vector3(-123, -1,0), Quaternion.identity);
//            }
        }
    }
}

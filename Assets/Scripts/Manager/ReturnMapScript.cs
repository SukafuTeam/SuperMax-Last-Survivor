using UnityEngine;
using System.Collections;

public class ReturnMapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Game.Data.filtro.SetActive(true);
            Game.Data.nevoa.SetActive(true);
            var res = GameObject.FindGameObjectsWithTag("itens");
            foreach(var i in res)
            {
                if(i.name != "armario_lim" && i.name != "ralo" && i.name != "radio")
                    Destroy(i);
            }
            Game.Data.player.transform.position = Game.Data.returnPlace;
        }
    }
}

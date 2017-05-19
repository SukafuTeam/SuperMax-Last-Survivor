using UnityEngine;
using System.Collections;

public class LimpDoorScript : MonoBehaviour {

    public bool hasCofre;
    public bool hasAcido;

    public GameObject cofre;
    public GameObject acido;

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
            Game.Data.player.transform.position = new Vector3(-70,-2,0);    

            if(hasCofre && !Game.Data.itens[0][2]) {
                Instantiate(cofre, new Vector3(-72, 0.6f, 0), Quaternion.identity);
            } else if(hasAcido &&!Game.Data.itens[2][1]) {
                Instantiate(acido, new Vector3(-68, -0.3f, 0), Quaternion.identity);
            }
        }

    }
}

using UnityEngine;
using System.Collections;

public class BathDoorScript : MonoBehaviour {

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
            Game.Data.player.transform.position = new Vector3(-156,-2.3f,0);
        }
    }
}

using UnityEngine;
using System.Collections;

public class CellDoorScript : MonoBehaviour {

    public bool hasFaca;
    public bool hasChave;
    public bool hasluva;
    public bool hasfio;

    public GameObject faca;
    public GameObject chave;
    public GameObject luva;
    public GameObject fio;

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
            Game.Data.player.transform.position = new Vector3(-50,-1.5f,0);

            if(hasFaca && !Game.Data.itens[0][0]) {
                Instantiate(faca, new Vector3(-51.7f, 0.2f, 0), Quaternion.identity);
            } else if(hasChave && !Game.Data.itens[1][0]) {
                Instantiate(chave, new Vector3(-51.7f, 0.2f, 0), Quaternion.identity);
            } else if(hasluva && !Game.Data.itens[2][0]) {
                Instantiate(luva, new Vector3(-51.7f, 0.2f, 0), Quaternion.identity);
            } else if(hasfio && !Game.Data.itens[0][1]) {
                Instantiate(fio, new Vector3(-51.7f, 0.2f, 0), Quaternion.identity);
            }
        }
    }
}

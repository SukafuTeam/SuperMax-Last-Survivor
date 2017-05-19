using UnityEngine;
using UnityEngine.UI;

public class InventarioScript : MonoBehaviour {

    public Image img;
    public int line;
    public int column;

	// Use this for initialization
	void Start () {
        img = this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        var col = img.color;

        if(Game.Data.itens[line][column])
        {
            col = Color.white;
        }
        else 
        {
            col = Color.black;
        }

        img.color = col;
	}
}

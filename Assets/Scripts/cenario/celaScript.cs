using UnityEngine;
using System.Collections;

public enum TipoSala { Cela, Limpeza, Seguranca, Vestiario };

public class celaScript : MonoBehaviour {

    public Sprite[] sprites; 
    public TipoSala tipo;

	// Use this for initialization
	void Start () {
        if(tipo == TipoSala.Cela)
        {
            foreach(CellDoorScript door in GetComponentsInChildren<CellDoorScript>())
            {
                // Add spawn logic here
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void RandomSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}

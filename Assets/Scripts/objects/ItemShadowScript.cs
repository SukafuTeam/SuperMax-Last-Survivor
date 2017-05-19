using UnityEngine;
using System.Collections;

public class ItemShadowScript : MonoBehaviour {

    public SpriteRenderer referencia;

	// Use this for initialization
	void Start () {
        var ren = this.gameObject.GetComponent<SpriteRenderer>();
        ren.sprite = referencia.sprite;
        ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, 0.4f);
	}
	
	// Update is called once per frame
	void Update () {
        var ren = this.gameObject.GetComponent<SpriteRenderer>();
        ren.enabled = Vector3.Distance(this.gameObject.transform.position, Game.Data.player.transform.position) < 2;
	}
}

using UnityEngine;
using UnityEngine.UI;

public class showComponents : MonoBehaviour {

    Image img;

	// Use this for initialization
	void Start () {
        img = this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        img.enabled = Game.Data.showingMochila;
	}
}

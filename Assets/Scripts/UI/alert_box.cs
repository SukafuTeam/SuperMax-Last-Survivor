using UnityEngine;
using UnityEngine.UI;

public class alert_box : MonoBehaviour {

    public Image img;
    public Button btn;
    public Text txt;

	// Use this for initialization
	void Start () {
        img = this.gameObject.GetComponent<Image>();
        btn = this.gameObject.GetComponent<Button>();
        txt = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(img != null)
            img.enabled = Game.Data.showingModal;
        if(btn != null)
            btn.enabled = Game.Data.showingModal;
        if(txt != null)
            txt.enabled = Game.Data.showingModal;
	}
}

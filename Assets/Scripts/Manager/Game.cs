using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public static Game Data;
    public TerrainGenerator generator;
    public GameObject player;
    public GameObject filtro;
    public GameObject nevoa;

    public LayerMask clickLayer;

    // Room vlues
    public Vector3 returnPlace;

    // Timer
    public UnityEngine.UI.Text clock;
    public float timeLeft;
    public Image statico;
    public AudioSource src;

    // Mochila
    public bool showingMochila;
    public Animator mochila_animator;

    // items
    public bool[][] itens;

    public bool showingModal;
    public Text modalMessage;

    public float tempoJogando;

    public void Awake()
    {
        if(Data == null)
        {
            Data = this;

            itens = new bool[3][];  
            for(int i = 0; i < 3; i++)
            {
                itens[i] = new bool[3];
            }

            tempoJogando = 0;
        }
    }

    public static GameObject getObjectTouched() {
        if(Input.touchCount > 0) {

            if(Input.GetTouch(0).phase == TouchPhase.Began) {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero, Mathf.Infinity, Game.Data.clickLayer);//, Mathf.Infinity, touchMask);

                if(hit.collider != null)
                {

                    return hit.collider.gameObject;
                }
            }
        }
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, Game.Data.clickLayer);//, Mathf.Infinity, touchMask);

            if(hit.collider != null)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

	// Use this for initialization
	void Start () {
        generator.Generate();
        filtro.SetActive(true);
        nevoa.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        tempoJogando += Time.deltaTime;

        timeLeft -= Time.deltaTime;

        int intSec = (int)timeLeft;
        int seconds = intSec % 60; 
        int minutes = (intSec / 60) % 60; 

        clock.text = string.Format("{0}:{1}", minutes, seconds);

        if(timeLeft < 15)
        {
            src.volume += 0.001f;
            var col = statico.color;
            col.a += 0.001f;
            statico.color = col;

            if(col.a >= 1)
            {
                Application.LoadLevel("cena_sustinho");
            }
        }
	}

    public void SwitchMochila()
    {
        showingMochila = !showingMochila;
        mochila_animator.SetTrigger("Switch");
    }

    public void Messages(string message)
    {
        if(showingModal)
        {
            showingModal = false;
            return;
        }

        modalMessage.text = message;
        showingModal = true;
    }
}

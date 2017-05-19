using UnityEngine;
using System.Collections;

public class SoundData : MonoBehaviour {

    public static SoundData Data;
    public AudioSource src;

	// Use this for initialization
    public void Awake () {
        if(Data == null)
        {
            Data = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            SoundData.Stop();
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void Start()
    {
        if(SoundData.Data != null)
            SoundData.Data.src.Play();
    }

    public static void Stop()
    {
        if(SoundData.Data != null)
            SoundData.Data.src.Stop();
    }
}

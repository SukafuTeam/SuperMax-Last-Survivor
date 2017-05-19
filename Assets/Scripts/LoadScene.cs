using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Loadlevel(string level_name)
    {
        Application.LoadLevel(level_name);
    }

    public void LoadLevelAsync(string level_name)
    {
        Application.LoadLevelAsync(level_name);
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

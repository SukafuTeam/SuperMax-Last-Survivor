using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var position = transform.position;
        position.x += Random.Range(-5.5f, 5.5f);
        position.y += Random.Range(-5.5f, 5.5f);

        transform.position = position;
	}
}

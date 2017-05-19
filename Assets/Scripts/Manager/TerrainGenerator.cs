using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TerrainGenerator : MonoBehaviour {

    public GameObject roomsRoot;

    public GameObject cela;
    public GameObject seguranca;
    public GameObject limpeza;
    public GameObject vestiario;

    private bool hasShower;

    private int hadSeg;
    private bool hadbath;

    private bool hadFaca;
    private bool hadChave;

    // Quest related stuff
    public bool criouFaca;
    public bool criouFio;
    public bool criouCofre;

    public bool criouChave;
    public bool criouRadio;

    public bool criouLuva;
    public bool criouAcido;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [ContextMenu("Generate")]
    public void Generate()
    {
        #if UNITY_EDITOR
        ClearAllrooms();
        #endif

        hadSeg = 0;
        hadbath = false;

        criouFaca = false;
        criouFio = false;
        criouCofre = false;

        criouChave = false;
        criouRadio = false;

        criouLuva = false;
        criouAcido = false;

        GenerateForY(10);
        GenerateForY(2);
        GenerateForY(-6);
        GenerateForY(-14);

    }

    [ContextMenu("Clear rooms")]
    public void ClearAllrooms()
    {
        for(int i = roomsRoot.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(roomsRoot.transform.GetChild(i).gameObject);
        }
    }

    public void GenerateForY(float y)
    {
        GameObject clone;
        float x = -20;
        bool hadBig = false;
        bool hadLimp = false;

        int max = 5;

        while(x <= 10)
        {
            if(hadBig)
            {
                max = 2;
            }

            if(hadLimp)
            {
                max = 1;

            }

            int ran = Random.Range(0, max);

            if(y == -14)
            {
                if(hadSeg < 2)
                    ran = 3;
                if(!hadbath)
                    ran = 2;
            }

            if(hadbath && ran == 2)
                ran = 0;

            switch(ran)
            {
            case 0:
                clone = Spawn(cela, new Vector3(x, y, 0), Quaternion.identity);
                clone.GetComponent<celaScript>().RandomSprite();
                clone.transform.parent = roomsRoot.transform;
                x += 7;
                if(!criouFaca) {
                    criouFaca = true;
                    var res = clone.gameObject.GetComponentsInChildren<CellDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasFaca = true;
                    }
                } else if(!criouChave) {
                    criouChave = true;
                    var res = clone.gameObject.GetComponentsInChildren<CellDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasChave = true;
                    }
                } else if(!criouLuva) {
                    criouLuva = true;
                    var res = clone.gameObject.GetComponentsInChildren<CellDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasluva = true;
                    }
                } else if(!criouFio) {
                    criouFio = true;
                    var res = clone.gameObject.GetComponentsInChildren<CellDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasfio = true;
                    }
                }
                
                break;
            case 1:
                clone = Spawn(limpeza, new Vector3(x, y, 0), Quaternion.identity);
                clone.transform.parent = roomsRoot.transform;
                hadLimp = true;
                x += 7;
                if(!criouCofre) {
                    criouCofre = true;
                    var res = clone.gameObject.GetComponentsInChildren<LimpDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasCofre = true;
                    }
                } else if(!criouAcido) {
                    criouAcido = true;
                    var res = clone.gameObject.GetComponentsInChildren<LimpDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasAcido = true;
                    }
                }
                break;
            case 2:
                clone = Spawn(vestiario, new Vector3(x, y, 0), Quaternion.identity);
                clone.transform.parent = roomsRoot.transform;
                hadbath = true;
                x += 17;
                hadBig = true;
                break;
            case 3:
                clone = Spawn(seguranca, new Vector3(x, y, 0), Quaternion.identity);
                clone.transform.parent = roomsRoot.transform;
                hadSeg ++;
                x += 12;
                hadBig = true;
                break;
                if(!criouRadio) {
                    criouRadio = true;
                    var res = clone.gameObject.GetComponentsInChildren<SafeDoorScript>();
                    foreach(var i in res)
                    {
                        i.hasRadio = true;
                    }
                }
            }
        }
    }

    static public GameObject Spawn(GameObject gameObject, Vector3 position, Quaternion rotation) {
#if UNITY_EDITOR
        if(gameObject != null) {
            GameObject clone = PrefabUtility.InstantiatePrefab(gameObject) as GameObject;
            clone.transform.position = position;
            clone.transform.rotation = rotation;
            return clone;
        }
#else
        if(gameObject != null) {
        return Object.Instantiate(gameObject, position, rotation) as GameObject;
        }
#endif
        return null;
    }
}

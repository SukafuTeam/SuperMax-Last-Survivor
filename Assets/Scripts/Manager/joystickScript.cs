using UnityEngine;
using UnityEngine.EventSystems;

public class joystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public static joystickScript Data;

    public Vector3 initialpos;
    public float deltaX;
    public float deltaY;

    public float maxDist;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public void Awake()
    {
        if(Data == null)
        {
            Data = this;
        }
    }

	// Use this for initialization
	void Start () {
        initialpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag(PointerEventData data)
    {
        up = false;
        down = false;
        left = false;
        right = false;

        Vector3 newPos = Vector3.zero;

        deltaX = (int)(data.position.x - initialpos.x);
        newPos.x = deltaX;

        deltaY = (int)(data.position.y - initialpos.y);
        newPos.y = deltaY;

        float deadzone = 20;
#if UNITY_IOS
        deadzone = 40;
#endif

        if(newPos.y > deadzone)
            up = true;
        if(newPos.y < -deadzone)
            down = true;
        if(newPos.x > deadzone)
            right = true;
        else if(newPos.x < -deadzone)
            left = true;

        if(newPos.magnitude > maxDist)
            newPos =  newPos.normalized * maxDist;

        transform.position = new Vector3(initialpos.x + newPos.x, initialpos.y + newPos.y, initialpos.z + newPos.z);
    }


    public void OnPointerUp(PointerEventData data)
    {
        transform.position = initialpos;
        up = false;
        down = false;
        left = false;
        right = false;
    }


    public void OnPointerDown(PointerEventData data) 
    {
    }
}

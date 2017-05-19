using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float MoveSpeed;

    private Animator animator;

    public LayerMask wallLayer;

	// Use this for initialization
	void Start () {
        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool moveUp;
        bool moveDown;
        bool moveLeft;
        bool moveRight;


//#if UNITY_IOS || UNITY_ANDROID
//        moveUp = joystickScript.Data.up;
//        moveDown = joystickScript.Data.down;
//        moveLeft = joystickScript.Data.left;
//        moveRight = joystickScript.Data.right;
//#else
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
//#endif


        var pos = this.gameObject.transform.position;
        if(moveUp)
        {
            if(CheckIfFree(1))
                pos.y += MoveSpeed * Time.deltaTime;
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        if(moveDown)
        {
            if(CheckIfFree(2))
                pos.y -= MoveSpeed * Time.deltaTime;
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        if(moveLeft)
        {
            if(CheckIfFree(3))
                pos.x -= MoveSpeed * Time.deltaTime;
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }
        if(moveRight)
        {
            if(CheckIfFree(4))
                pos.x += MoveSpeed * Time.deltaTime;
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
        }
        this.gameObject.transform.position = pos;

        if(moveUp || moveDown || moveLeft || moveRight)
        {
            animator.SetBool("Walk", true);    
        }
        else 
        {
            animator.SetBool("Walk", false);
        }
	}

    public bool CheckIfFree(int direction)
    {
        switch(direction)
        {
        case 1:
            return RayUp();
        case 2:
            return RayDown();
        case 3:
            return RayLeft();
        case 4:
            return RayRight();
        }
        return false;
    }

    bool RayUp()
    {
        var origin = this.gameObject.transform.position;
        origin.y += 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;
        
        origin.x += 0.5f;
        hit = Physics2D.Raycast(origin, Vector2.up, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.x -= 1;
        hit = Physics2D.Raycast(origin, Vector2.up, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        return true;

    }

    bool RayDown()
    {
        var origin = this.gameObject.transform.position;
        origin.y -= 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.x += 0.5f;
        hit = Physics2D.Raycast(origin, Vector2.down, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.x -= 1;
        hit = Physics2D.Raycast(origin, Vector2.down, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        return true;
    }

    bool RayLeft()
    {
        var origin = this.gameObject.transform.position;
        origin.x -= 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.left, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.y += 0.5f;
        hit = Physics2D.Raycast(origin, Vector2.left, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.y -= 1;
        hit = Physics2D.Raycast(origin, Vector2.left, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        return true;
    }

    bool RayRight()
    {
        var origin = this.gameObject.transform.position;
        origin.x += 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.y += 0.5f;
        hit = Physics2D.Raycast(origin, Vector2.right, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        origin.y -= 1;
        hit = Physics2D.Raycast(origin, Vector2.right, MoveSpeed * Time.deltaTime, wallLayer);
        if(hit.collider != null)
            return false;

        return true;
    }
}

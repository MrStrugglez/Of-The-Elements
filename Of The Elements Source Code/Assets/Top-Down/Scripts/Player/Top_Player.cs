using UnityEngine;
using System.Collections;

public class Top_Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public static bool iscontrallable = true;

    private Vector3 Direction;
    private string Priority;
    private string temp = "none";
    private Animator anim;
    private bool PlayerMoving;
    private Vector2 LastMoveDirection;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (iscontrallable)
        {
            MovePlayer();
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            Priority = null;
            temp = "none";
            anim.SetBool("PlayerMoving", false);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void MovePlayer()
    {
        Direction = Vector3.zero;
        PlayerMoving = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Priority = "up";
            if (temp == "none")
            {
                temp = Priority;
            }
        }
        if (Priority == "up")
        {
            PlayerMoving = true;
            Direction = Vector3.up;
            LastMoveDirection = new Vector2(0f, Direction.y);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (temp == "up" && Priority == "up")
            {
                temp = "none";
            }
            else if (temp == "up")
            {
                temp = Priority;
            }
            Priority = temp;
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            Priority = "down";
            if (temp == "none")
            {
                temp = Priority;
            }
        }
        if (Priority == "down")
        {
            PlayerMoving = true;
            Direction = Vector3.down;
            LastMoveDirection = new Vector2(0f, Direction.y);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (temp == "down" && Priority == "down")
            {
                temp = "none";
            }
            else if (temp == "down")
            {
                temp = Priority;
            }
            Priority = temp;
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Priority = "left";
            if (temp == "none")
            {
                temp = Priority;
            }
        }
        if (Priority == "left")
        {
            PlayerMoving = true;
            Direction = Vector3.left;
            LastMoveDirection = new Vector2(Direction.x, 0f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (temp == "left" && Priority == "left")
            {
                temp = "none";
            }
            else if (temp == "left")
            {
                temp = Priority;
            }
            Priority = temp;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            Priority = "right";
            if (temp == "none")
            {
                temp = Priority;
            }
        }
        if (Priority == "right")
        {
            PlayerMoving = true;
            Direction = Vector3.right;
            LastMoveDirection = new Vector2(Direction.x, 0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (temp == "right" && Priority == "right")
            {
                temp = "none";
            }
            else if (temp == "right")
            {
                temp = Priority;
            }
            Priority = temp;
        }

        GetComponent<Rigidbody2D>().AddForce(Direction * speed * Time.deltaTime);
        anim.SetFloat("MoveX", Direction.x);
        anim.SetFloat("MoveY", Direction.y);
        anim.SetBool("PlayerMoving", PlayerMoving);
        anim.SetFloat("LastMoveX", LastMoveDirection.x);
        anim.SetFloat("LastMoveY", LastMoveDirection.y);
    }

}
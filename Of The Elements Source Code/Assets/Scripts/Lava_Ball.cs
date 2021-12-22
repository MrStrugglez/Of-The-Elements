using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lava_Ball : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float minXPos;
    [SerializeField]
    private float maxXPos;
    
    private bool moveRight;
    public static bool attack;

    public static string lavaBallBeingAttacked;

    // Use this for initialization
    void Start ()
    {
        attack = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float currentXPos = GetComponent<Transform>().position.x;

        if (currentXPos > maxXPos)
        {
            moveRight = false;
        }
        else if (currentXPos < minXPos)
        {
            moveRight = true;
        }
        
        if (attack && gameObject.name == lavaBallBeingAttacked)
        {
            GetComponent<Animator>().SetBool("walk", false);

            attack = false;
        }

        Move();
    }

    private void Move()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;

            transform.Rotate(Vector3.back * 4);

            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;

            transform.Rotate(Vector3.forward * 4);

            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}

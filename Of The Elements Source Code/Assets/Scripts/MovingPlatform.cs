using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private bool goFast;

    private int movementSpeed;
    private bool goRight;

    private Rigidbody2D platformRigidBody;

    // Use this for initialization
    void Start()
    {
        platformRigidBody = gameObject.GetComponent<Rigidbody2D>();

        goRight = true;

        if (goFast)
        {
            movementSpeed = 10;
        }
        else
        {
            movementSpeed = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (platformRigidBody.position.x > 40)
        {
            goRight = false;
        }
        else if (platformRigidBody.position.x < 10)
        {
            goRight = true;
        }

        if (goRight)
        {
            platformRigidBody.transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else 
        {
            platformRigidBody.transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
    }
}

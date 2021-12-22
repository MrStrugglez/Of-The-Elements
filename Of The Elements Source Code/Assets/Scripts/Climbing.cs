using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour 
{
    [SerializeField]
    private float climbingSpeed;

    private GameObject playerGameObject;
    private Rigidbody2D playerRigidBody;

    private float vertical;

	// Use this for initialization
	void Start () 
    {
        playerGameObject = GameObject.Find("Player");
        playerRigidBody = playerGameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        vertical = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, vertical * climbingSpeed);

        if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S))
        {
            playerRigidBody.AddForce(new Vector3(0,10.5f,0));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerRigidBody.velocity = Vector2.zero;
    }
}

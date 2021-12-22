using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : MonoBehaviour
{
    [SerializeField]
    private Transform[] touchPoints;

    [SerializeField]
    private LayerMask whatIsAnObject;

    private Rigidbody2D rigidBody;
    private Animator playerAnimator;
    
    public float pointRadius;

    public int jumpForce;
        
	// Use this for initialization
	void Start () 
    {
        rigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

    }

    protected void Update()
    {
        BounceObject();
    }

    private void BounceObject()
    {
        if (rigidBody.velocity.y <= 0)
        {
            foreach (Transform point in touchPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, pointRadius, whatIsAnObject);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != this.gameObject)
                    {
                        colliders[i].gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);

                        playerAnimator.SetBool("land", false);
                        playerAnimator.SetTrigger("jump");
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    [SerializeField]
    private bool flipX;
    
    [SerializeField]
    private bool flyRight;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float minXPos;

    [SerializeField]
    private float maxXPos;
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > maxXPos)
        {
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(minXPos, transform.position.y, transform.position.z), transform.rotation);
        }

        if (transform.position.x < minXPos)
        {
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(maxXPos, transform.position.y, transform.position.z), transform.rotation);
        }

        Fly();
	}

    private void Fly()
    {
        GetComponent<SpriteRenderer>().flipX = flipX;

        if (flyRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}

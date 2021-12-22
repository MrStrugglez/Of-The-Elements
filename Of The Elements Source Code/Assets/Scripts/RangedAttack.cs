using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    float playerXPos, elementXPos;

	// Use this for initialization
	void Start ()
    {
        playerXPos = GameObject.Find("Player").GetComponent<Transform>().position.x;
        elementXPos = transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerXPos > elementXPos)
        {
            if (transform.position.x > playerXPos - 20)
            {
                transform.position += Vector3.left * 10 * Time.deltaTime;
                
                if (gameObject.name == "Elements_Earth(Clone)")
                {
                    transform.Rotate(Vector3.forward * 10);
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (transform.position.x < playerXPos + 20)
            {
                transform.position += Vector3.right * 10 * Time.deltaTime;

                if (gameObject.name == "Elements_Earth(Clone)")
                {
                    transform.Rotate(Vector3.forward * -10);
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

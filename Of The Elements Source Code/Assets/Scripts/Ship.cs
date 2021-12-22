using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private bool shipRocked;

	// Use this for initialization
	void Start ()
    {
        shipRocked = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shipRocked)
        {
            StartCoroutine(RockShip());
        }
    }

    IEnumerator RockShip()
    {
        shipRocked = false;
        
        for (int i = 0; i < 100; i++)
        {
            transform.Rotate(Vector3.forward * 0.1f);

            if (i < 25)
            {
                yield return new WaitForSeconds(0.05f);
            }
            else if (i < 75)
            {
                yield return new WaitForSeconds(0.03f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
        
        for (int i = 0; i < 100; i++)
        {
            transform.Rotate(Vector3.forward * -0.1f);

            if (i < 25)
            {
                yield return new WaitForSeconds(0.05f);
            }
            else if (i < 75)
            {
                yield return new WaitForSeconds(0.03f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
        }

        shipRocked = true;
    }
}

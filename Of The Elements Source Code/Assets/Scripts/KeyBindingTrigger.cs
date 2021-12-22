using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindingTrigger : MonoBehaviour
{
    public static bool inTrigger;

	// Use this for initialization
	void Start ()
    {
        inTrigger = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ElementSelection.inTrigger && Input.GetKeyDown(KeyCode.R))
        {
            ElementSelection.inTrigger = false;

            Destroy(GameObject.Find("KeyBindingTrigger"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            inTrigger = true;
        }
    }
}

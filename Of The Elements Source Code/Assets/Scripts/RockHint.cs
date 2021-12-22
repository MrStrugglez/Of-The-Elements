using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHint : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("Rock1").GetComponent<SpriteRenderer>().sprite.name == "Rock2")
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mustachio_Text.ChangeMustachioText("If you can't beat them, fight rock with rock!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Mustachio_Text.EnableMustachioText(false);
    }
}

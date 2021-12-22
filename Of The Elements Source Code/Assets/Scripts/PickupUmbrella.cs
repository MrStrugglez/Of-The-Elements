using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUmbrella : MonoBehaviour
{
	private GameObject player;

    [SerializeField]
    private Sprite newSprite;

	private bool umbrellaPickedUp;
	private bool ableToPickup;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		umbrellaPickedUp = false;
		ableToPickup = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((ableToPickup) && (Input.GetKeyDown(KeyCode.E)))
		{
			umbrellaPickedUp = true;
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		ableToPickup = true;

		if (umbrellaPickedUp)
        {
            GetComponent<Transform>().position = player.GetComponent<Transform>().position;

            player.GetComponent<Animator>().enabled = false;

            player.GetComponent<SpriteRenderer>().sprite = newSprite;
            gameObject.SetActive(false);

			player.GetComponent<Rigidbody2D> ().gravityScale = 0.2f;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
        ableToPickup = false;
	}
}

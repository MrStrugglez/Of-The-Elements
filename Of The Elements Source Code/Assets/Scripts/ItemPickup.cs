using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private Image slotImage;

    public static bool onItem;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            onItem = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                onItem = false;

                int i = 0;

                do
                {
                    i++;
                    slotImage = GameObject.Find("Item" + i).GetComponent<Image>();
                } while ((slotImage.sprite != null) && (i < 10));

                if (slotImage.sprite == null)
                {
                    slotImage.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;

                    Color c = slotImage.color;
                    c.a = 1;
                    slotImage.color = c;

                    this.gameObject.SetActive(false);
                }
                else
                {
                    //No space in inventory
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            onItem = false;
        }
    }
}

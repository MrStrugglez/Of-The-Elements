using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Player_Front_Layer_Transparent : MonoBehaviour
{
    [SerializeField]
    int toplayer = 0, botlayer = 0;

    private SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = toplayer;
            sprite.color = new Color(1f, 1f, 1f, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingOrder = botlayer;
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }
    }

}

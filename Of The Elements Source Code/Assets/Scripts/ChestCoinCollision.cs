using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCoinCollision : MonoBehaviour
{
    private PolygonCollider2D playerCollider;
    private CircleCollider2D coinCollider;

    // Use this for initialization
    void Start()
    {
        playerCollider = GameObject.Find("Player").GetComponent<PolygonCollider2D>();
        coinCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetCollision();
    }

    void SetCollision()
    {
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            Physics2D.IgnoreCollision(playerCollider, coinCollider, false);

            StopMovement();
        }
    }

    void StopMovement()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}

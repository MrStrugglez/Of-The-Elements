using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialChestCoinCollision : MonoBehaviour 
{
    private PolygonCollider2D playerCollider;
    private CircleCollider2D coinCollider;

	// Use this for initialization
	void Start () 
    {
        playerCollider = GameObject.Find("Player").GetComponent<PolygonCollider2D>();
        coinCollider = GetComponent<CircleCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, coinCollider, true);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour 
{
    [SerializeField]
    private Sprite oldSprite;

    [SerializeField]
    private Sprite newSprite1;

    [SerializeField]
    private Sprite newSprite2;

    [SerializeField]
    private bool breakBarrel;

    [SerializeField]
    private bool giveCoin;
    
    private SpriteRenderer spriteRenderer;

    private bool fPressed;
    private bool ePressed;
    private bool canBreak;
    
	// Use this for initialization
	void Start () 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        fPressed = false;
        ePressed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (canBreak)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fPressed = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ePressed = true;
            }

            if (breakBarrel)
            {
                if (fPressed)
                {
                    if (spriteRenderer.sprite == oldSprite)
                    {
                        spriteRenderer.sprite = newSprite1;
                    }
                    else if (spriteRenderer.sprite == newSprite1)
                    {
                        spriteRenderer.sprite = newSprite2;

                        if (giveCoin)
                        {
                            GameObject instance = null;

                            //Load coin
                            instance = Instantiate(Resources.Load("Big Coin", typeof(GameObject))) as GameObject;

                            instance.transform.Translate(GetComponent<Transform>().position.x + 13, GetComponent<Transform>().position.y + 5, GetComponent<Transform>().position.z);
                            instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

                            //Add collision script
                            instance.AddComponent<ChestCoinCollision>();
                        }
                    }

                    fPressed = false;
                }
            }
            else
            {
                if (ePressed)
                {
                    spriteRenderer.sprite = newSprite1;

                    ePressed = false;
                }
            }
        }
	}

    private void OnTriggerEnter2D()
    {
        canBreak = true;
    }
    
    void OnTriggerExit2D()
    {
        canBreak = false;
    }
}

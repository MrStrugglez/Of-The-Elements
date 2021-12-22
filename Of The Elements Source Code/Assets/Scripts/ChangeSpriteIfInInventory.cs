using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSpriteIfInInventory : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteToFind;

    [SerializeField]
    private Sprite newSprite;

    [SerializeField]
    private bool giveCoin;

    [SerializeField]
    private bool makeBridge;

    private SpriteRenderer spriteRenderer;

    private bool spriteChanged;
    public static bool onItem;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteChanged = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            onItem = true;
        }   
    }

    void OnTriggerStay2D()
    {
        if ((spriteChanged == false) && (Input.GetKeyDown(KeyCode.E)))
        {
            int i = 1;

            while ((i <= 10) && (GameObject.Find("Item" + i).GetComponent<Image>().sprite != spriteToFind))
            {
                i++;
            }

            if (i != 11)
            {
                GameObject.Find("Item" + i).GetComponent<Image>().sprite = null;

                spriteRenderer.sprite = newSprite;

                //Set alpha of image to 0
                Color c = GameObject.Find("Item" + i).GetComponent<Image>().color;
                c.a = 0;
                GameObject.Find("Item" + i).GetComponent<Image>().color = c;

                spriteChanged = true;

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

                if (makeBridge)
                {
                    onItem = false;
                    Destroy(gameObject.GetComponent<PolygonCollider2D>());

                    //Load log bridge
                    GameObject instance = null;

                    instance = Instantiate(Resources.Load("Log Bridge", typeof(GameObject))) as GameObject;

                    instance.transform.Translate(GetComponent<Transform>().position.x + 13, GetComponent<Transform>().position.y - 10.8f, GetComponent<Transform>().position.z);
                }
            }
            else
            {
                if (gameObject.name.Contains("Tree"))
                {
                    Mustachio_Text.ChangeMustachioText("Chop, Chop, Chop...");
                }
                else if (gameObject.name.Contains("Chest") && SceneManager.GetActiveScene().name == "Level1_1")
                {
                    Mustachio_Text.ChangeMustachioText("Remember, every lock has a key...");
                }
                else if (gameObject.name.Contains("Chest") && SceneManager.GetActiveScene().name == "Level1_3")
                {
                    Mustachio_Text.ChangeMustachioText("I found this chest but can't get it open.  It looks like there's a cave down there.  Why don't you explore it and see what you can find...");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            onItem = false;
            Mustachio_Text.EnableMustachioText(false);
        }
    }
}

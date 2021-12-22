using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Obstacle_Collission : MonoBehaviour
{
    [SerializeField]
    private bool useFire;

    [SerializeField]
    private bool useWater;

    [SerializeField]
    private bool useEarth;

    [SerializeField]
    private bool useAir;

    private int count;

    // Use this for initialization
    void Start ()
    {
        count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (useAir && collision.name == "Elements_Air(Clone)")
        {
            count++;

            if (count == 1)
            {
                Destroy(gameObject.GetComponent<PolygonCollider2D>());
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Barrel2", typeof(Sprite)) as Sprite;
                gameObject.AddComponent<PolygonCollider2D>();
            }
            else if (count == 2)
            {
                Destroy(gameObject.GetComponent<PolygonCollider2D>());
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Barrel3", typeof(Sprite)) as Sprite;
                gameObject.AddComponent<PolygonCollider2D>();
            }
            else if (count == 3)
            {
                Destroy(this.gameObject);

                Mustachio_Text.ChangeMustachioText("Oh, you found my hiding spot. Well... Yer doing good wee child. Look a Fanjangler!");
            }
        }
        else if(useWater && collision.name == "Elements_Water(Clone)")
        {
            if (gameObject.name.Contains("Lavaball"))
            {
                count++;

                if (count == 1)
                {
                    Lava_Ball.lavaBallBeingAttacked = gameObject.name;
                    Lava_Ball.attack = true;
                }
                else if (count == 2)
                {
                    //Load coin
                    GameObject instance = Instantiate(Resources.Load("Coin", typeof(GameObject))) as GameObject;
                    instance.transform.Translate(GetComponent<Transform>().position.x + 6, GetComponent<Transform>().position.y + 5, GetComponent<Transform>().position.z);

                    //Add collision script
                    instance.AddComponent<ChestCoinCollision>();
                    
                    Destroy(this.gameObject);
                }
            }
            else
            {
                count++;

                if (count == 1)
                {
                    gameObject.GetComponent<Transform>().localScale = new Vector3(1.7f, 1.7f, 0);
                }
                else if (count == 2)
                {
                    gameObject.GetComponent<Transform>().localScale = new Vector3(1.4f, 1.4f, 0);
                }
                else if (count == 3)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (useEarth && collision.name == "Elements_Earth(Clone)")
        {
            count++;

            if (count == 1)
            {
                Destroy(gameObject.GetComponent<PolygonCollider2D>());
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Rock2", typeof(Sprite)) as Sprite;
                gameObject.AddComponent<PolygonCollider2D>();
            }
            else if (count == 2)
            {
                Destroy(gameObject.GetComponent<PolygonCollider2D>());
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Rock3", typeof(Sprite)) as Sprite;
                gameObject.AddComponent<PolygonCollider2D>();
            }
            else if (count == 3)
            {
                Destroy(this.gameObject);
            }
        }
        else if (useFire && collision.name == "Elements_Fire(Clone)")
        {
            count++;

            if (count == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("IceSpike2", typeof(Sprite)) as Sprite;
            }
            else if (count == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("IceSpike3", typeof(Sprite)) as Sprite;
            }
            else if (count == 3)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.name == "Elements_Fire(Clone)" || collision.name == "Elements_Water(Clone)" || collision.name == "Elements_Air(Clone)" || collision.name == "Elements_Earth(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
}

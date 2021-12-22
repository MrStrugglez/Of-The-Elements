using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float minXPos;
    [SerializeField]
    private float maxXPos;

    private bool moveRight;
    private bool attack;
    private bool destroy;
    private bool takeDamage;
    public static bool npcAttackable;

    // Use this for initialization
    void Start()
    {
        moveRight = true;
        attack = false;
        destroy = false;
        takeDamage = false;
        npcAttackable = false;
        
        GetComponent<Animator>().SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        float currentXPos = GetComponent<Transform>().position.x;

        if (currentXPos > maxXPos)
        {
            moveRight = false;
        }
        else if (currentXPos < minXPos)
        {
            moveRight = true;
        }

        if (GetComponent<Animator>().GetBool("walk"))
        {
            Move();
        }
        else
        {
            if (Side_DialogueManager.answerCorrect)
            {
                GetComponent<Animator>().SetBool("scared", true);
                npcAttackable = true;

                Side_DialogueManager.answerCorrect = false;
            }
            else if (Side_DialogueManager.answerIncorrect)
            {
                GetComponent<Animator>().SetTrigger("attack");

                takeDamage = true;

                Side_DialogueManager.answerIncorrect = false;
            }

            if (npcAttackable)
            {
                if (attack && Input.GetKeyDown(KeyCode.F))
                {
                    destroy = true;
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    attack = true;
                }
            }
        }

        TakeDamage();
        AttackNPC();
    }

    private void TakeDamage()
    {
        if (takeDamage)
        {
            int lives;

            for (lives = 5; lives > 0; lives--)
            {
                if (GameObject.Find("Health_" + lives).GetComponent<Image>().sprite.name == "Health_1")
                {
                    GameObject.Find("Health_" + lives).GetComponent<Image>().sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;

                    break;
                }
            }

            if (lives == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                lives = 5;
            }

            takeDamage = false;
        }
    }

    private void Move()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

            if (gameObject.name == "Crab1")
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            GetComponent<BoxCollider2D>().offset = new Vector2(0.08f, GetComponent<BoxCollider2D>().offset.y);
        }
        else
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);

            if (gameObject.name == "Crab1")
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            GetComponent<BoxCollider2D>().offset = new Vector2(-0.08f, GetComponent<BoxCollider2D>().offset.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GetComponent<Animator>().SetBool("walk", false);
        }

        if (gameObject.name == "Crab1")
        {
            Side_DialogueManager.ShowBox(Encounter.Crab);
        }
        else if (gameObject.name == "Zombie1")
        {
            Side_DialogueManager.ShowBox(Encounter.Zombie);
        }
        else if (gameObject.name == "Pierate1")
        {
            Side_DialogueManager.ShowBox(Encounter.Pierate1);
        }
        else if (gameObject.name == "Pierate2")
        {
            Side_DialogueManager.ShowBox(Encounter.Pierate2);
        }
        else if (gameObject.name == "GhostPierate1")
        {
            Side_DialogueManager.ShowBox(Encounter.Ghost_Pierate1);
        }
        else if (gameObject.name == "GhostPierate2")
        {
            Side_DialogueManager.ShowBox(Encounter.Ghost_Pierate2);
        }
        else if (gameObject.name == "GhostPierate3")
        {
            Side_DialogueManager.ShowBox(Encounter.Ghost_Pierate3);
        }
        else if (gameObject.name == "LonePierate1")
        {
            Side_DialogueManager.ShowBox(Encounter.Lone_Pierate1);
        }
        else if (gameObject.name == "LonePierate2")
        {
            Side_DialogueManager.ShowBox(Encounter.Lone_Pierate2);
        }
    }

    void AttackNPC()
    {
        if (attack)
        {
            GetComponent<Animator>().SetTrigger("hurt");
        }

        if (destroy)
        {
            Destroy(this.gameObject);

            GameObject instance = null;

            //Load coin
            instance = Instantiate(Resources.Load("Big Coin", typeof(GameObject))) as GameObject;

            instance.transform.Translate(GetComponent<Transform>().position.x + 13, GetComponent<Transform>().position.y + 5, GetComponent<Transform>().position.z);
            instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

            //Add collision script
            instance.AddComponent<ChestCoinCollision>();

            destroy = false;
            npcAttackable = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && GetComponent<Animator>().GetBool("scared") == false)
        {
            GetComponent<Animator>().SetBool("walk", true);
        }

        Mustachio_Text.EnableMustachioText(false);
        Side_DialogueManager.HideBox();
    }
}

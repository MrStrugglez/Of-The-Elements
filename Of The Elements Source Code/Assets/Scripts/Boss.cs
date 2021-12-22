using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private Animator animator;

    private float xPos;

    private bool moveToPlayer;
    private bool moveAwayFromPlayer;

    public static bool bossAttacking;
    public static bool bossAttacked;
    
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();

        animator.SetFloat("speed", -1);
        animator.SetFloat("speedMultiplier", 1);

        moveToPlayer = false;
        moveAwayFromPlayer = false;
        bossAttacking = false;
        bossAttacked = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        xPos = transform.position.x;
        
        if (GetComponent<Animator>().GetFloat("speed") < 0)
        {
            if (xPos > 25)
            {
                animator.SetFloat("speedMultiplier", 1);
                Move(5);
            }
            else
            {
                animator.SetFloat("speed", 0);
            }
        }
        else
        {
            if (!Player_BossArena.playerAttacking && !bossAttacking && !Side_DialogueManager.answerCorrect && !Side_DialogueManager.answerIncorrect)
            {
                if (!Side_DialogueManager.boxShown)
                {
                    if (SceneManager.GetActiveScene().name == "Level1_1_Boss")
                    {
                        Side_DialogueManager.ShowBox(Encounter.Boss_Pierate);
                    }
                    else if (SceneManager.GetActiveScene().name == "Level1_2_Boss")
                    {
                        Side_DialogueManager.ShowBox(Encounter.Boss_GhostPierate);
                    }
                    else if (SceneManager.GetActiveScene().name == "Level1_3_Boss")
                    {
                        Side_DialogueManager.ShowBox(Encounter.Boss_Magma);
                    }
                }
            }

            if (Side_DialogueManager.answerCorrect)
            {
                Player_BossArena.playerAttack = true;

                Side_DialogueManager.answerCorrect = false;
            }
            else if (Side_DialogueManager.answerIncorrect)
            {
                moveToPlayer = true;
                bossAttacking = true;

                Side_DialogueManager.answerIncorrect = false;
            }
        }
        
        MoveToPlayer();

        MoveAwayFromPlayer();
    }

    private void Move(int speed)
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void MoveToPlayer()
    {
        if (moveToPlayer)
        {
            animator.SetFloat("speed", -1);

            if (xPos > 16)
            {
                animator.SetFloat("speedMultiplier", 2.5f);
                Move(10);
            }
            else
            {
                animator.SetFloat("speed", 0);

                moveToPlayer = false;

                animator.SetTrigger("attack");

                StartCoroutine(Wait1());
            }
        }
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.5f);
        
        bossAttacked = true;
        
        StartCoroutine(Wait2());
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.5f);

        moveAwayFromPlayer = true;
    }

    private void MoveAwayFromPlayer()
    {
        if (moveAwayFromPlayer)
        {
            animator.SetFloat("speed", -1);

            if (gameObject.name == "Boss_Pierate" || gameObject.name == "Boss_GhostPierate")
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            if (xPos < 25)
            {
                animator.SetFloat("speedMultiplier", 2.5f);
                Move(-10);
            }
            else
            {
                animator.SetFloat("speed", 0);
                moveAwayFromPlayer = false;
                bossAttacking = false;

                if (gameObject.name == "Boss_Pierate" || gameObject.name == "Boss_GhostPierate")
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}

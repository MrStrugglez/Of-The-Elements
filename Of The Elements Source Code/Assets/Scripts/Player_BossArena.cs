using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BossArena : MonoBehaviour
{
    private Animator animator;
    private float xPos;

    private bool moveToBoss;
    private bool moveAwayFromBoss;

    public static bool playerAttack;
    public static bool playerAttacking;
    public static bool playerAttacked;

    // Use this for initialization
    protected void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetFloat("speed", 1);
        animator.SetFloat("speedMultiplier", 1);

        moveToBoss = false;
        moveAwayFromBoss = false;
        playerAttack = false;
        playerAttacking = false;
        playerAttacked = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        xPos = transform.position.x;

        if (xPos < 12)
        {
            Move(5);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        if (playerAttack && !playerAttacking)
        {
            moveToBoss = true;
            playerAttacking = true;
            playerAttack = false;
        }
        
        MoveToBoss();
        MoveAwayFromBoss();
    }

    private void MoveToBoss()
    {
        if (moveToBoss)
        {
            animator.SetFloat("speed", 1);

            if (xPos < 22)
            {
                animator.SetFloat("speedMultiplier", 2.5f);
                Move(10);
            }
            else
            {
                animator.SetFloat("speed", 0);

                moveToBoss = false;

                animator.SetTrigger("attack");

                StartCoroutine(Wait1());
            }
        }
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.2f);

        playerAttacked = true;

        StartCoroutine(Wait2());
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.3f);

        moveAwayFromBoss = true;
    }

    private void MoveAwayFromBoss()
    {
        if (moveAwayFromBoss)
        {
            animator.SetFloat("speed", 1);

            GetComponent<SpriteRenderer>().flipX = true;

            if (xPos > 12)
            {
                animator.SetFloat("speedMultiplier", 2.5f);
                Move(-10);
            }
            else
            {
                animator.SetFloat("speed", 0);
                moveAwayFromBoss = false;
                playerAttacking = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    private void Move(int speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
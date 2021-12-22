using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss_Stronghands_Movement_Dialogue : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 Pos2 = Vector3.zero, Pos3 = Vector3.zero, Pos4 = Vector3.zero, Pos5 = Vector3.zero;

    [SerializeField]
    float DetectableRange;

    private bool movingTpos2 = false, movingTpos3 = false, movingTpos4 = false, movingTpos5 = false, check1 = false, check2 = false, check3 = false, animcheck = false;
    private float range;
    private Animator anim;
    private Transform Target;
    private string Instruction = "SPACE: Continue";
    private Top_DialogueManager dManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        dManager = FindObjectOfType<Top_DialogueManager>();
    }

    void Update()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        range = Vector2.Distance(GetComponent<Transform>().position, Target.position);

        if (range <= DetectableRange && !check3)
        {
            if (!check1)
            {
                Top_Player.iscontrallable = false;
                anim.SetBool("Moving", false);
                dManager.ShowBox("Ooo, a willing adventurer?", Instruction, "Miss Stronghands");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check1 = true;
                }
            }
            else if (!check2)
            {
                dManager.ShowBox("Not really...", Instruction, "Player");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check2 = true;
                }
            }
            else if (!check3)
            {
                dManager.ShowBox("Here to fight the pie-rates are you? Great! See you at the fight.", Instruction, "Miss Stronghands");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check3 = true;
                    dManager.HideBox();
                    Top_Player.iscontrallable = true;
                    movingTpos2 = true;
                }
            }
        }
        else
        {
            MoveAI();
        }
    }

    private void MoveAI()
    {
        animcheck = false;

        if (movingTpos2 == true)
        {
            if (transform.localPosition == Pos2)
            {
                movingTpos2 = false;
                movingTpos3 = true;
                anim.SetBool("Down", false);
                anim.SetBool("Moving", false);
                animcheck = true;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos2, speed * Time.deltaTime);
                anim.SetBool("Down", true);
                anim.SetBool("Moving", true);
            }
        }

        if (movingTpos3 == true && animcheck == false)
        {
            if (transform.localPosition == Pos3)
            {
                movingTpos3 = false;
                movingTpos4 = true;
                anim.SetBool("Left", false);
                anim.SetBool("Moving", false);
                animcheck = true;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos3, speed * Time.deltaTime);
                anim.SetBool("Left", true);
                anim.SetBool("Moving", true);
            }
        }

        if (movingTpos4 == true && animcheck == false)
        {
            if (transform.localPosition == Pos4)
            {
                movingTpos4 = false;
                movingTpos5 = true;
                anim.SetBool("Down", false);
                anim.SetBool("Moving", false);
                animcheck = true;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos4, speed * Time.deltaTime);
                anim.SetBool("Down", true);
                anim.SetBool("Moving", true);
            }
        }

        if (movingTpos5 == true && animcheck == false)
        {
            if (transform.localPosition == Pos5)
            {
                gameObject.SetActive(false);
                anim.enabled = false;
                animcheck = true;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos5, speed * Time.deltaTime);
                anim.SetBool("Right", true);
                anim.SetBool("Moving", true);
            }
        }
    }
}

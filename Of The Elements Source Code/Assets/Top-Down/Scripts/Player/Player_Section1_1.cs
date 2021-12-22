using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Section1_1 : MonoBehaviour
{
    private float speed = 1;

    [SerializeField]
    Vector3 Pos1 = Vector3.zero, Pos2 = Vector3.zero, Pos3 = Vector3.zero;

    public static bool check1 = true, check2 = false, check3 = false, animcheck = false;
    private Animator anim;
    private Top_DialogueManager dManager;
    private string Instruction = "SPACE: Continue";

    void Start()
    {
        anim = GetComponent<Animator>();
        dManager = FindObjectOfType<Top_DialogueManager>();
    }

    void Update()
    {
        animcheck = false;

        if (check1)
        {
            if (transform.localPosition == Pos1)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Moving", false);
                animcheck = true;
                dManager.ShowBox("Welcome to the Fight! But it's too late now and the pie-rates are too many. Well take shelter in Mr O'neely's house for tonight so they don't spot us.", Instruction, "Miss Stronghands");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check1 = false;
                    check2 = true;
                    Miss_StrongHands_Section1_1.check1 = true;
                    dManager.HideBox();
                    speed = 2;
                }
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos1, speed * Time.deltaTime);
                anim.SetBool("Right", true);
                anim.SetBool("Moving", true);
            }
        }
        if (check2 && !animcheck)
        {
            if (transform.localPosition == Pos2)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Moving", false);
                animcheck = true;
                check2 = false;
                check3 = true;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos2, speed * Time.deltaTime);
                anim.SetBool("Right", true);
                anim.SetBool("Moving", true);
            }
        }
        if (check3 && !animcheck)
        {
            if (transform.localPosition == Pos3)
            {
                Section1_1_Exit.showdragon = true;
                anim.SetBool("Up", false);
                anim.SetBool("Moving", false);
                animcheck = true;
                check3 = false;
                gameObject.SetActive(false);
                anim.gameObject.SetActive(false);
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos3, speed * Time.deltaTime);
                anim.SetBool("Up", true);
                anim.SetBool("Moving", true);
            }
        }
    }
}

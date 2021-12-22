using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mr_Beardly_Dialogue_Default : MonoBehaviour
{
    [SerializeField]
    float DetectableRange;

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 Pos1 = Vector3.zero, Pos2 = Vector3.zero;

    [SerializeField]
    Vector3 aPos2 = Vector3.zero, aPos3 = Vector3.zero;

    [SerializeField]
    bool Verticle = false, Horizontal = false;

    [SerializeField]
    int Answer;


    public bool moving = true;
    private bool movingTpos2 = true, animcheck = false, animcheck2 = true;
    private bool amovingTpos2 = true, amovingTpos3 = false, answercheck = false;
    private float time, Delay = 0;
    private Animator anim;
    private Top_DialogueManager dManager;
    private float range;
    private Transform Target;
    private bool dialogue = false, MoveToPosition = false;
    public static bool NPCCheck = false, PlayerExitInteraction = false, PlayerExitInteraction2 = false;
    private string Instruction = "SPACE: Continue";

    void Start()
    {
        anim = GetComponent<Animator>();
        dManager = FindObjectOfType<Top_DialogueManager>();
    }

    void Update()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        range = Vector2.Distance(GetComponent<Transform>().position, Target.position);
        if (PlayerExitInteraction2 && !NPCCheck)
        {
            MrBeardlyQuestion();
        }
        else if (Mr_ONeely.NPCCheck == true && Constable_Jeffry_Dialogue.NPCCheck == true && Lady_Emily_Dialogue.NPCCheck == true && Mr_Poppysock_Dialogue.NPCCheck == true && Mrs_AppleCrown.NPCCheck == true && amovingTpos3 == false)
        {
            PlayerExitInteraction = true;
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("Moving", false);
            PlayerExitMethod();
            MoveToPosition = true;
        }
        else if (!PlayerExitInteraction)
        {
            if (range <= DetectableRange)
            {
                moving = false;
                dManager.ShowBox("...", null, "Mr. Beardly");
                dialogue = true;
            }
            else if (dialogue)
            {
                moving = true;
                dManager.HideBox();
                dialogue = false;
            }
            time = Time.time * 1000;
            if (moving)
            {
                MoveAI();
            }
            else
            {
                anim.SetBool("Moving", false);
            }
        }
        else
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("Moving", false);
            PlayerExitMethod();
        }
    }

    private void MoveAI()
    {
        if (transform.localPosition == Pos2 && Delay == 0)
        {
            movingTpos2 = false;
            Delay = time + 5000;
            anim.SetBool("Moving", false);
        }
        else if (transform.localPosition == Pos1 && Delay == 0)
        {
            movingTpos2 = true;
            Delay = time + 5000;
            anim.SetBool("Moving", false);
        }

        if (movingTpos2 == true && time >= Delay && Horizontal == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos2, speed * Time.deltaTime);
            Delay = 0;
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
            anim.SetBool("Moving", true);
        }
        else if (time >= Delay && Horizontal == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos1, speed * Time.deltaTime);
            Delay = 0;
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            anim.SetBool("Moving", true);
        }

        if (movingTpos2 == true && time >= Delay && Verticle == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos2, speed * Time.deltaTime);
            Delay = 0;
            anim.SetBool("Down", true);
            anim.SetBool("Up", false);
            anim.SetBool("Moving", true);
        }
        else if (time >= Delay && Verticle == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos1, speed * Time.deltaTime);
            Delay = 0;
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);
            anim.SetBool("Moving", true);
        }
    }

    private void PlayerExitMethod()
    {
        if (animcheck2)
        {
            animcheck2 = false;
            animcheck = true;
        }
        else
        {
            animcheck = false;
            speed = 4;
        }


        if (amovingTpos2 == true && animcheck == false)
        {
            if (transform.localPosition == aPos2)
            {
                amovingTpos2 = false;
                amovingTpos3 = true;
                anim.SetBool("Down", false);
                anim.SetBool("Moving", false);
                animcheck = true;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, aPos2, speed * Time.deltaTime);
                anim.SetBool("Down", true);
                anim.SetBool("Moving", true);
            }
        }

        if (amovingTpos3 == true && animcheck == false)
        {
            if (transform.localPosition == aPos3)
            {
                if (!MoveToPosition)
                {
                    anim.SetBool("Right", false);
                    anim.SetBool("Moving", false);
                    animcheck = true;
                    dManager.ShowBox(" Listen here adventurer. My knee’s been twitching all day. Nothing good awaits you down this path.", Instruction, "Mr. Beardly");
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        amovingTpos3 = false;
                        dManager.HideBox();
                        Top_Player.iscontrallable = true;
                        speed = 1;
                        PlayerExitInteraction = true;
                        Dans_Amore_exit.tempcheck = true;
                    }
                }
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, aPos3, speed * Time.deltaTime);
                anim.SetBool("Right", true);
                anim.SetBool("Moving", true);
            }
        }
    }

    public void MrBeardlyQuestion()
    {
        dManager.Showinputfield();
        if (!answercheck)
        {
            dManager.ShowBox("How far you plan on walking, pal?", Instruction, "Mr. Beardly ");
        }
        else
        {
            if (Answer > 29)
            {
                dManager.ShowBox("you'll go straight past the fish market and into the volcano if you go that far", Instruction, "Mr. Beardly ");
            }
            else if (Answer < 29)
            {
                dManager.ShowBox("That’s not nearly far enough. You'll end up between nothing and nowhere", Instruction, "Mr. Beardly ");
            }
            else if (Answer == 29)
            {
                dManager.ShowBox(" Alright, away with you. Oh and if you happen to see my axe, would you return it to me. I lost it somewhere slicing some pie.", Instruction, "Mr. Beardly ");
                dManager.Hideinputfield();
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    NPCCheck = true;
                    dManager.HideBox();
                    Top_Player.iscontrallable = true;
                }
            }
        }

        if (dManager.inputFieldVisible)
        {
            Instruction = "Press ENTER";
        }
        else
        {
            Instruction = "SPACE: Continue";
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            Answer = int.Parse(dManager.GetInputValue());
            answercheck = true;            
        }
    }
}

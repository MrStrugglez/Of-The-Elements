using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr_ONeely : MonoBehaviour
{
    [SerializeField]
    float DetectableRange;

    private string Instruction = "SPACE: Continue";
    private Top_DialogueManager dManager;
    private float range;
    private Transform Target;
    private float time;
    public static bool NPCCheck = false;

    private bool check1 = false, check2 = false, check3 = false, check4 = false, dialogue = false;

    void Start()
    {
        dManager = FindObjectOfType<Top_DialogueManager>();
    }

    void Update()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        range = Vector2.Distance(GetComponent<Transform>().position, Target.position);

        if (range <= DetectableRange)
        {
            if (!check1)
            {
                gameObject.GetComponent<AI_Movement_Simple>().moving = false;
                Top_Player.iscontrallable = false;
                dManager.ShowBox("Sorry I can’t talk now. I’m busy", Instruction, "Mr. O ’Neely");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check1 = true;
                    dManager.HideBox();
                    gameObject.GetComponent<AI_Movement_Simple>().moving = true;
                    Top_Player.iscontrallable = true;
                    time = (Time.time * 1000) + 5000;
                }
            }
            else if ((Time.time * 1000) >= time && !check2 && check1 == true)
            {
                Top_Player.iscontrallable = false;
                gameObject.GetComponent<AI_Movement_Simple>().moving = false;
                dManager.ShowBox("What do you want?", Instruction, "Mr. O ’Neely");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check2 = true;
                }
            }
            else if (!check3 && check2 == true)
            {
                dManager.ShowBox("Is something wrong? Do you need help?", Instruction, "Player");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check3 = true;
                }
            }
            else if (!check4 && check3 == true)
            {
                dManager.ShowBox("I don’t think you can help. The pie-rates raided my shop down the coast and I lost everything. Plus the shop is almost 29 kwaggles down the coast. It’s hopelessly too far for someone to travel alone. ", Instruction, "Player");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check4 = true;
                    dManager.HideBox();
                    gameObject.GetComponent<AI_Movement_Simple>().moving = true;
                    Top_Player.iscontrallable = true;
                    time = (Time.time * 1000) + 5000;
                    NPCCheck = true;
                }
            }
            else if ((Time.time * 1000) >= time && check4 == true)
            {
                gameObject.GetComponent<AI_Movement_Simple>().moving = false;
                dManager.ShowBox("29 kwaggles away…", null, "Mr. O ’Neely");
                dialogue = true;
            }
        }
        else if (dialogue)
        {
            dManager.HideBox();
            dialogue = false;
            gameObject.GetComponent<AI_Movement_Simple>().moving = true;
        }
    }
}

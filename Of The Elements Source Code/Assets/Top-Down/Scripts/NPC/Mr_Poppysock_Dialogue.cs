using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr_Poppysock_Dialogue : MonoBehaviour
{
    [SerializeField]
    float DetectableRange;

    private string Instruction = "SPACE: Continue";
    private Top_DialogueManager dManager;
    private float range;
    private Transform Target;
    private float time;
    public static bool NPCCheck = false;

    private bool check1 = false, dialogue = false;

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
                dManager.ShowBox("Greetings future citizen. Welcome to Dans-amore, the best city on the island. I promise it can cater to your every need. If you feel like staying Mr. Beardly is the best furniner this side of the forest and if you need something to eat you can visit our bakery. Mrs. Applecrown has the best pastries in the land. Your adventure awaits!", Instruction, "Mr. Poppysock");
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    check1 = true;
                    dManager.HideBox();
                    gameObject.GetComponent<AI_Movement_Simple>().moving = true;
                    Top_Player.iscontrallable = true;
                    time = (Time.time * 1000) + 5000;
                    NPCCheck = true;
                }
            }
            else
            {
                if ((Time.time * 1000) >= time)
                {
                    gameObject.GetComponent<AI_Movement_Simple>().moving = false;
                    dManager.ShowBox("Remember to vote!", null, "Mr. Poppysock");
                    dialogue = true;
                }
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

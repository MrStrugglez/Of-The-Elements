using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constable_Jeffry_Dialogue : MonoBehaviour
{
    [SerializeField]
    float DetectableRange;

    private Top_DialogueManager dManager;
    private float range;
    private Transform Target;
    private bool dialogue = false;
    public static bool NPCCheck = false;

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
            gameObject.GetComponent<AI_Movement_Simple>().moving = false;
            dManager.ShowBox("If I get my hands on that dwarf!", null, "Constable Jeffry");
            dialogue = true;
            NPCCheck = true;
        }
        else if (dialogue)
        {
            gameObject.GetComponent<AI_Movement_Simple>().moving = true;
            dManager.HideBox();
            dialogue = false;
        }
    }
}

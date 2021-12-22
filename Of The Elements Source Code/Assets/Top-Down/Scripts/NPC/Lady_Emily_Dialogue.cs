using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lady_Emily_Dialogue : MonoBehaviour
{

    [SerializeField]
    float DetectableRange;

    private Top_DialogueManager dManager;
    private float range;
    private Transform Target;
    public static bool NPCCheck = false;
    private bool dialogue = false;

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
            dManager.ShowBox("Did you hear about the attack on the castle? Terrible isn’t it.", null, "Lady Emily");
            NPCCheck = true;
            dialogue = true;
        }
        else if (dialogue)
        {
            gameObject.GetComponent<AI_Movement_Simple>().moving = true;
            dManager.HideBox();
            dialogue = false;
        }
    }
}

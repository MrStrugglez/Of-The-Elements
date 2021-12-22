using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mrs_AppleCrown : MonoBehaviour
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
            dManager.ShowBox("Why hello there dearie. Do you want some pastries? Unfortunately my daughter isn’t here today so the shop is closed, but come again soon. ", null, "Mrs. AppleCrown ");
            dialogue = true;
            NPCCheck = true;
        }
        else if (dialogue)
        {
            dManager.HideBox();
            dialogue = false;
        }
    }
}

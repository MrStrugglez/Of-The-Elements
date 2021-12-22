using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement_Simple : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 Pos1 = Vector3.zero, Pos2 = Vector3.zero;

    [SerializeField]
    bool Verticle = false, Horizontal =false;

    public bool moving = true;
    private bool movingTpos2 = true;
    private float time, Delay = 0;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
}

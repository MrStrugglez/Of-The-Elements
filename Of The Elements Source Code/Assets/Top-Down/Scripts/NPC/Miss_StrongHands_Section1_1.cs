using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss_StrongHands_Section1_1 : MonoBehaviour
{
    private float speed = 2;

    [SerializeField]
    Vector3 Pos1 = Vector3.zero, Pos2 = Vector3.zero;

    public static bool check1 = false;
    private bool check2 = false, animcheck = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
                check1 = false;
                check2 = true;
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
                anim.SetBool("Up", false);
                anim.SetBool("Moving", false);
                animcheck = true;
                gameObject.SetActive(false);
                anim.gameObject.SetActive(false);
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Pos2, speed * Time.deltaTime);
                anim.SetBool("Up", true);
                anim.SetBool("Moving", true);
            }
        }
    }
}

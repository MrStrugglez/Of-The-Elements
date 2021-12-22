using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings : MonoBehaviour
{
    private GameObject keyBindingA, keyBindingD, keyBindingSpace, textMove, textJump, keyBindingE1, keyBindingE2, keyBindingF, textAttack, keyBindingQ, keyBindingR;
    private bool showMovement, showJump, showAttack;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(PulseKeyBinding());

        keyBindingA = GameObject.Find("KeyBinding_A");
        keyBindingD = GameObject.Find("KeyBinding_D");
        textMove = GameObject.Find("Text_Move");
        keyBindingSpace = GameObject.Find("KeyBinding_Space");
        textJump = GameObject.Find("Text_Jump");
        keyBindingE1 = GameObject.Find("KeyBinding_E(1)");
        keyBindingE2 = GameObject.Find("KeyBinding_E(2)");
        keyBindingF = GameObject.Find("KeyBinding_F");
        textAttack = GameObject.Find("Text_Attack");
        keyBindingQ = GameObject.Find("KeyBinding_Q");
        keyBindingR = GameObject.Find("KeyBinding_R");

        keyBindingSpace.SetActive(false);
        textJump.SetActive(false);
        keyBindingF.SetActive(false);
        textAttack.SetActive(false);
        keyBindingE1.SetActive(false);
        keyBindingE2.SetActive(false);
        keyBindingQ.SetActive(false);
        keyBindingR.SetActive(false);

        showMovement = true;
        showJump = false;
        showAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showMovement)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                keyBindingA.SetActive(false);
                keyBindingD.SetActive(false);
                textMove.SetActive(false);

                showAttack = true;
                showMovement = false;
            }
        }

        if (showAttack)
        {
            keyBindingF.SetActive(true);
            textAttack.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                keyBindingF.SetActive(false);
                textAttack.SetActive(false);

                showJump = true;
                showAttack = false;
            }
        }

        if (showJump)
        {
            keyBindingSpace.SetActive(true);
            textJump.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                keyBindingSpace.SetActive(false);
                textJump.SetActive(false);

                showJump = false;
            }
        }
    }

    private void ChangeKeyBindingSize(GameObject keyBinding, int oldXY, int newXY)
    {
        if (keyBinding.GetComponent<Transform>().localScale == new Vector3(oldXY, oldXY, -2206.669f))
        {
            keyBinding.GetComponent<Transform>().localScale = new Vector3(newXY, newXY, -2206.669f);
        }
        else
        {
            keyBinding.GetComponent<Transform>().localScale = new Vector3(oldXY, oldXY, -2206.669f);
        }
    }

    IEnumerator PulseKeyBinding()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            ChangeKeyBindingSize(keyBindingA, 35, 37);
            ChangeKeyBindingSize(keyBindingD, 35, 37);
            ChangeKeyBindingSize(keyBindingSpace, 30, 32);
            ChangeKeyBindingSize(keyBindingF, 30, 32);
            ChangeKeyBindingSize(keyBindingE1, 35, 37);
            ChangeKeyBindingSize(keyBindingE2, 35, 37);
            ChangeKeyBindingSize(keyBindingQ, 35, 37);
            ChangeKeyBindingSize(keyBindingR, 35, 37);

            if (ItemPickup.onItem)
            {
                keyBindingE1.SetActive(true);
            }
            else
            {
                keyBindingE1.SetActive(false);
            }

            if (ChangeSpriteIfInInventory.onItem)
            {
                keyBindingE2.SetActive(true);
            }
            else
            {
                keyBindingE2.SetActive(false);
            }

            if (KeyBindingTrigger.inTrigger)
            {
                keyBindingQ.SetActive(true);
            }
            else
            {
                keyBindingQ.SetActive(false);
            }

            if (ElementSelection.inTrigger)
            {
                keyBindingR.SetActive(true);
            }
            else
            {
                keyBindingR.SetActive(false);
            }
        }
    }
}

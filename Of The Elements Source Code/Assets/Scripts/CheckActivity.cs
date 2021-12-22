using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckActivity : MonoBehaviour
{
    private int secondsOfInactivity;
    private bool playerInactive;

	// Use this for initialization
	void Start ()
    {
        secondsOfInactivity = 0;
        StartCoroutine(CountSeconds());

        playerInactive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKey)
        {
            secondsOfInactivity = 0;
        }
        
        if (secondsOfInactivity == 10)
        {
            playerInactive = true;

            if (SceneManager.GetActiveScene().name == "Level1_1")
            {
                Mustachio_Text.ChangeMustachioText("♪ Bingo Bongo lift those legs ♪");
            }
            else if (SceneManager.GetActiveScene().name == "Level1_2")
            {
                Mustachio_Text.ChangeMustachioText("♪ Lookey Lookey I see a cookie ♪");
            }
            else if (SceneManager.GetActiveScene().name == "Level1_3")
            {
                Mustachio_Text.ChangeMustachioText("♪ Get some heat on those soles! ♪");
            }            
        }

        if (playerInactive && Input.anyKey)
        {
            Mustachio_Text.EnableMustachioText(false);
        }
    }

    IEnumerator CountSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsOfInactivity++;
        }
    }
}

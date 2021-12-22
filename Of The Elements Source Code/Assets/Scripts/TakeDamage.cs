using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            int lives;
            
            for (lives = 5; lives > 0; lives--)
            {
                if (GameObject.Find("Health_" + lives).GetComponent<Image>().sprite.name == "Health_1")
                {
                    GameObject.Find("Health_" + lives).GetComponent<Image>().sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;

                    break;
                }
            }
            
            if (lives == 1)
            {
                LEVEL_DATA_STORE.Level1_3Reload = false;

                if (SceneManager.GetActiveScene().name == "Level1_3_Cave")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }

                lives = 5;
            }
            else
            {
                GameObject.Find("Player").GetComponent<Transform>().position = LEVEL_DATA_STORE.Level1_3CheckPointCoordinates;
            }

            if (gameObject.tag == "Level1_1_Spikes")
            {
                Mustachio_Text.ChangeMustachioText("Up-up and away we go...");
            }
            else if (gameObject.tag == "Level1_2_Spikes")
            {
                Mustachio_Text.ChangeMustachioText("Yikes! Lookout for Spikes!");
            }
            else if (gameObject.tag == "Level1_3_Spikes")
            {
                Mustachio_Text.ChangeMustachioText("Woah! That’s hot!");
            }

            StartCoroutine(Waiter());
        }
    }

    IEnumerator Waiter()
    {
        Color c1 = new Color();
        c1.a = 0;

        Color c2 = GameObject.Find("Player").GetComponent<SpriteRenderer>().color;

        for (int i = 0; i < 4; i++)
        {
            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = c1;
            yield return new WaitForSeconds(0.1f);

            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = c2;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2);

        Mustachio_Text.EnableMustachioText(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeDamage_BossArena : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Boss.bossAttacking && Boss.bossAttacked)
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
            
            Boss.bossAttacked = false;

            if (lives == 1)
            {
                LEVEL_DATA_STORE.Level1_3Reload = false;

                if (SceneManager.GetActiveScene().name == "Level1_3_Boss")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }

                lives = 5;
            }
        }

        else if (Player_BossArena.playerAttacking && Player_BossArena.playerAttacked)
        {
            List<string> bossHeartSprites = new List<string>();
            bossHeartSprites.Add("Health_MagmaBoss_1");
            bossHeartSprites.Add("Health_PierateBoss_1");
            bossHeartSprites.Add("Health_GhostPierateBoss_1");

            int lives;

            for (lives = 1; lives <= 5; lives++)
            {
                if (bossHeartSprites.Contains(GameObject.Find("Health_Boss_" + lives).GetComponent<Image>().sprite.name))
                {
                    GameObject.Find("Health_Boss_" + lives).GetComponent<Image>().sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;

                    break;
                }
            }

            Player_BossArena.playerAttacked = false;

            if (lives == 5)
            {
                if (GameObject.Find("Boss_Magma") != null)
                {
                    GameObject.Find("Boss_Magma").SetActive(false);
                }
                else if (GameObject.Find("Boss_Pierate") != null)
                {
                    GameObject.Find("Boss_Pierate").SetActive(false);
                }
                else if (GameObject.Find("Boss_GhostPierate") != null)
                {
                    GameObject.Find("Boss_GhostPierate").SetActive(false);
                }

                Destroy(GameObject.Find("Player").GetComponent<Player_BossArena>());
                GameObject.Find("Player").GetComponent<Side_Player>().enabled = true;

                GameObject instance = Instantiate(Resources.Load("Portal", typeof(GameObject))) as GameObject;
                instance.transform.Translate(12, 1, 0);
                instance.AddComponent<Portal>();
                instance.AddComponent<SaveCoinBalance>();
            }
        }
    }
}

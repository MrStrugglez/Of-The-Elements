using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    [SerializeField]
    private int nextScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Level1_3_Cave")
            {
                LEVEL_DATA_STORE.Level1_3Reload = true;
            }

            //-----Lives
            int lives = 0;

            for (int i = 1; i <= 5; i++)
            {
                if (GameObject.Find("Health_" + i).GetComponent<Image>().sprite.name == "Health_1")
                {
                    lives = i;
                }
            }

            LEVEL_DATA_STORE.lives = lives;
            //-----

            //-----Inventory Items
            List<string> inventoryItems = new List<string>();

            for (int i = 1; i <= 10; i++)
            {
                if (GameObject.Find("Item" + i).GetComponent<Image>().sprite != null)
                {
                    inventoryItems.Add(GameObject.Find("Item" + i).GetComponent<Image>().sprite.name);
                }
            }

            LEVEL_DATA_STORE.inventoryItems = inventoryItems;
            //-----

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + nextScene);
        }
    }
}

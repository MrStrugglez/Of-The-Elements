using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1_3_Load : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (!LEVEL_DATA_STORE.Level1_3Reload)
        {
            GameObject.Find("CoinBalanceText").GetComponent<Text>().text = LEVEL_DATA_STORE.Level1_3CoinBalance.ToString();

            for (int i = 1; i <= 5; i++)
            {
                GameObject.Find("Health_" + i).GetComponent<Image>().sprite = Resources.Load("Health_1", typeof(Sprite)) as Sprite;
            }

            LEVEL_DATA_STORE.Level1_3_CaveCoin1Taken = false;
            LEVEL_DATA_STORE.Level1_3_CaveKey1Taken = false;

            LEVEL_DATA_STORE.inventoryItems.Clear();
        }
        else
        {
            GameObject.Find("CoinBalanceText").GetComponent<Text>().text = LEVEL_DATA_STORE.coinBalance.ToString();

            for (int i = LEVEL_DATA_STORE.lives + 1; i <= 5; i++)
            {
                GameObject.Find("Health_" + i).GetComponent<Image>().sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;
            }

            if (LEVEL_DATA_STORE.Level1_3Coin1Taken == true)
            {
                GameObject.Find("Coin1").SetActive(false);
            }

            if (LEVEL_DATA_STORE.Level1_3Coin2Taken == true)
            {
                GameObject.Find("Coin2").SetActive(false);
            }

            if (LEVEL_DATA_STORE.Level1_3Coin3Taken == true)
            {
                GameObject.Find("Coin3").SetActive(false);
            }

            if (LEVEL_DATA_STORE.Level1_3Coin4Taken == true)
            {
                GameObject.Find("Coin4").SetActive(false);
            }

            GameObject.Find("Crate1").GetComponent<Transform>().position = LEVEL_DATA_STORE.Level1_3Crate1Pos;

            GameObject.Find("Player").GetComponent<Transform>().position = LEVEL_DATA_STORE.Level1_3PlayerPos;

            GameObject.Find("Barrel1").GetComponent<SpriteRenderer>().sprite = LEVEL_DATA_STORE.Level1_3Barrel1Sprite;
            GameObject.Find("Barrel2").GetComponent<SpriteRenderer>().sprite = LEVEL_DATA_STORE.Level1_3Barrel2Sprite;

            GameObject.Find("Chest1").GetComponent<SpriteRenderer>().sprite = LEVEL_DATA_STORE.Level1_3Chest1Sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1_3_Cave_Load : MonoBehaviour
{ 
	// Use this for initialization
	void Start ()
    {
        GameObject.Find("CoinBalanceText").GetComponent<Text>().text = LEVEL_DATA_STORE.coinBalance.ToString();

        for (int i = LEVEL_DATA_STORE.lives + 1; i <= 5; i++)
        {
            GameObject.Find("Health_" + i).GetComponent<Image>().sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;
        }

        if (LEVEL_DATA_STORE.Level1_3_CaveCoin1Taken == true)
        {
            GameObject.Find("Coin1").SetActive(false);
        }

        if (LEVEL_DATA_STORE.Level1_3_CaveKey1Taken == true)
        {
            GameObject.Find("Key1").SetActive(false);
        }        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

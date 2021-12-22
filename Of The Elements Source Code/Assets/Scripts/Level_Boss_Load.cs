using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Boss_Load : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        GameObject.Find("CoinBalanceText").GetComponent<Text>().text = LEVEL_DATA_STORE.coinBalance.ToString();

        for (int i = 1; i <= 5; i++)
        {
            GameObject.Find("Health_" + i).GetComponent<Image>().sprite = Resources.Load("Health_1", typeof(Sprite)) as Sprite;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

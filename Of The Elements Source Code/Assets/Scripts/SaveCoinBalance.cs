using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveCoinBalance : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LEVEL_DATA_STORE.coinBalance = int.Parse(GameObject.Find("CoinBalanceText").GetComponent<Text>().text);

        if (SceneManager.GetActiveScene().name == "Level1_2")
        {
            LEVEL_DATA_STORE.Level1_3CoinBalance = int.Parse(GameObject.Find("CoinBalanceText").GetComponent<Text>().text);
        }
    }
}

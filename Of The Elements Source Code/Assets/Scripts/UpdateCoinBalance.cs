using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoinBalance : MonoBehaviour
{
    private Text theText;
    
	// Use this for initialization
	void Start ()
    {
        theText = GameObject.Find("CoinBalanceText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Player")
        {
            if (this.gameObject.tag == "Big")
            {
                theText.text = (int.Parse(theText.text) + 5).ToString();
            }
            else
            {
                theText.text = (int.Parse(theText.text) + 1).ToString();
            }
                        
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialCoinBalance : MonoBehaviour 
{
    [SerializeField]
    private Text theText;

	// Use this for initialization
	void Start () 
    {
        theText.text = "0";
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}

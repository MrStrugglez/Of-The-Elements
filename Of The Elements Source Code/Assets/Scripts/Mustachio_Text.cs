using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mustachio_Text : MonoBehaviour
{
    static GameObject mText;
    static GameObject mustachio;

    // Use this for initialization
    void Start ()
    {
        mText = GameObject.Find("Mustachio_Panel_Text");
        mustachio = GameObject.Find("Mustachio");

        EnableMustachioText(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    public static void ChangeMustachioText(string text)
    {
        EnableMustachioText(true);
        GameObject.Find("Mustachio_Text").GetComponent<Text>().text = text;        
    }

    public static void EnableMustachioText(bool enable)
    {
        mustachio.SetActive(enable);

        mText.SetActive(enable);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementsMenu : MonoBehaviour
{
    Image elementMenuImage, airImage, fireImage, earthImage, waterImage;

    // Use this for initialization
    void Start ()
    {
        elementMenuImage = GameObject.Find("ElementMenu").GetComponent<Image>();
        airImage = GameObject.Find("Element_Air").GetComponent<Image>();
        fireImage = GameObject.Find("Element_Fire").GetComponent<Image>();
        earthImage = GameObject.Find("Element_Earth").GetComponent<Image>();
        waterImage = GameObject.Find("Element_Water").GetComponent<Image>();
    }

    //Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !Side_DialogueManager.boxShown)
        {
            elementMenuImage.enabled = true;
            airImage.enabled = true;
            fireImage.enabled = true;
            earthImage.enabled = true;
            waterImage.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            elementMenuImage.enabled = false;
            airImage.enabled = false;
            fireImage.enabled = false;
            earthImage.enabled = false;
            waterImage.enabled = false;
        }
    }
}

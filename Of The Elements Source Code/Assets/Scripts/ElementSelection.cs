using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image elementImage;
    string selectedElement;

    public static bool inTrigger;

    // Use this for initialization
    void Start()
    {
        elementImage = GameObject.Find("ElementImage").GetComponent<Image>();
        selectedElement = null;

        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && selectedElement != null)
        {
            elementImage.enabled = true;
            elementImage.sprite = Resources.Load(gameObject.GetComponent<Image>().sprite.name, typeof(Sprite)) as Sprite;

            Side_DialogueManager.ShowBox(Encounter.Element);
        }

        if (Side_DialogueManager.answerCorrect && Side_DialogueManager.selectingElement)
        {
            Side_DialogueManager.answerCorrect = false;
            Side_DialogueManager.selectingElement = false;
            
            if (KeyBindingTrigger.inTrigger)
            {
                KeyBindingTrigger.inTrigger = false;

                inTrigger = true;
            } 
        }

        if (Side_DialogueManager.answerIncorrect && Side_DialogueManager.selectingElement)
        {
            elementImage.enabled = false;
            elementImage.sprite = null;
            Side_DialogueManager.answerIncorrect = false;
            Side_DialogueManager.selectingElement = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(100, 100);
        selectedElement = gameObject.GetComponent<Image>().sprite.name;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(80, 80);
        selectedElement = null;
    }
}

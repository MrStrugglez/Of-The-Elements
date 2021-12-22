using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInventory : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < LEVEL_DATA_STORE.inventoryItems.Count; i++)
        {
            Image slotImage = GameObject.Find("Item" + (i+1)).GetComponent<Image>();
            
            slotImage.sprite = Resources.Load(LEVEL_DATA_STORE.inventoryItems[i], typeof(Sprite)) as Sprite;
            
            Color c = slotImage.color;
            c.a = 1;
            slotImage.color = c;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

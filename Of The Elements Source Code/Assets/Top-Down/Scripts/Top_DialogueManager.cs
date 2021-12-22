using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top_DialogueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dBox;

    [SerializeField]
    private Text dTextMain = null, dTextInstruction = null, dTextName = null;

    [SerializeField]
    private InputField dinputField;

    [SerializeField]
    private GameObject npcImage;

    private static float posX, posY, posZ;
    public bool inputFieldVisible;
    
    void Start()
    {
        HideBox();
        Hideinputfield();

        posX = 0.7f;
        posY = -0.2f;
        posZ = -2165.729f;
        
        inputFieldVisible = false;
    }

    void Update()
    {

    }

    public void ShowBox(string Maintext, string Instruction, string Name)
    {
        dBox.SetActive(true);
        dTextName.text = Name;
        dTextMain.text = Maintext;
        dTextInstruction.text = Instruction;

        if (inputFieldVisible)
        {
            dinputField.Select();
            dinputField.ActivateInputField();
        }

        npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("NPC_Placeholder", typeof(Sprite)) as Sprite;
        npcImage.GetComponent<Transform>().localPosition = new Vector3(posX, posY, posZ);
        npcImage.GetComponent<Transform>().localScale = new Vector3(120, 120, 25);
    }

    public void HideBox()
    {
        dBox.SetActive(false);
    }

    public void Showinputfield()
    {
        dinputField.gameObject.SetActive(true);
        
        inputFieldVisible = true;
    }

    public void Hideinputfield()
    {
        dinputField.gameObject.SetActive(false);
        inputFieldVisible = false;
    }

    public string GetInputValue()
    {
        return dinputField.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Encounter
{
    Element, Crab, Pierate1, Pierate2, Boss_Pierate, Ghost_Pierate1, Zombie, Ghost_Pierate2, Ghost_Pierate3, Boss_GhostPierate, Lone_Pierate1, Lone_Pierate2, Boss_Magma
}

public class Side_DialogueManager : MonoBehaviour
{
    private static GameObject dialogueBox, npcImage;
    private static Text mainText, npcNameText;
    private static InputField inputField;

    public static bool boxShown;
    private static int answer;
    public static bool answerCorrect;
    public static bool answerIncorrect;

    public static bool selectingElement;
    public static bool inBossFight;

    private static float posX, posY, posZ;

    private static int questionCount;
    private static int magicQuestionCount;

    void Start()
    {
        questionCount = 1;
        magicQuestionCount = 1;

        posX = 0.7f;
        posY = -0.2f;
        posZ = -2165.729f;

        answerCorrect = false;
        answerIncorrect = false;
        selectingElement = false;
        inBossFight = false;

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        dialogueBox = GameObject.Find("DialogueBox");
        npcImage = GameObject.Find("NPCImage");
        mainText = GameObject.Find("MainText").GetComponent<Text>();
        npcNameText = GameObject.Find("NPCText").GetComponent<Text>();

        HideBox();
    }

    void Update()
    {
        if (boxShown)
        {
            inputField.Select();
            inputField.ActivateInputField();

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (GameObject.Find("AnswerText").GetComponent<Text>().text == answer.ToString())
                {
                    answerCorrect = true;

                    HideBox();

                    Time.timeScale = 1;
                }
                else
                {
                    answerIncorrect = true;

                    if (!SceneManager.GetActiveScene().name.Contains("Boss"))
                    {
                        Mustachio_Text.ChangeMustachioText("Incorrect. Try again...");
                    }

                    StartCoroutine(Wait());

                    if (selectingElement)
                    {
                        HideBox();
                        Time.timeScale = 1;
                    }

                    if (inBossFight)
                    {
                        HideBox();

                        inBossFight = false;
                    }
                }
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);

        Mustachio_Text.EnableMustachioText(false);
    }

    public static void ShowBox(Encounter npc)
    {
        if ((npc != Encounter.Element && !NPC.npcAttackable) || (npc == Encounter.Element))
        {
            boxShown = true;

            dialogueBox.SetActive(true);
                 
            switch (npc)
            {
                case Encounter.Crab:
                    mainText.text = "Crrr Crrr. How many legs I got?";
                    answer = 6;

                    npcNameText.text = "Mr. Crab :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Crab", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_Crab") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX, posY, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Zombie:
                    mainText.text = "BRAIIIIINS! What is 2 divided by 2?!";
                    answer = 1;

                    npcNameText.text = "Mr. Zombie :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Zombie", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_Zombie") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX, posY + 12, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(90, 90, 25);
                    break;
                case Encounter.Element:
                    switch (magicQuestionCount)
                    {
                        case 1:
                            mainText.text = "3 + 5?";
                            answer = 8;
                            magicQuestionCount++;
                            break;
                        case 2:
                            mainText.text = "2 x 5?";
                            answer = 10;
                            magicQuestionCount++;
                            break;
                        case 3:
                            mainText.text = "21 - 6?";
                            answer = 15;
                            magicQuestionCount++;
                            break;
                        case 4:
                            mainText.text = "1 + 9?";
                            answer = 10;
                            magicQuestionCount++;
                            break;
                        case 5:
                            mainText.text = "8 / 2";
                            answer = 4;
                            magicQuestionCount = 0;
                            break;
                    }

                    selectingElement = true;

                    Time.timeScale = 0;

                    npcNameText.text = "Mustachio :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Mustachio", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/Mustachio") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX, posY + 10, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(25, 25, 25);
                    break;
                case Encounter.Boss_Magma:
                    switch (questionCount)
                    {
                        case 1:
                            mainText.text = "Answer me this. What is.....1+1?";
                            answer = 2;
                            questionCount++;
                            break;
                        case 2:
                            mainText.text = "2 x 5?";
                            answer = 10;
                            questionCount++;
                            break;
                        case 3:
                            mainText.text = "If I divide 20 by 10, what will the answer be?";
                            answer = 2;
                            questionCount++;
                            break;
                        case 4:
                            mainText.text = "2 + 11?";
                            answer = 13;
                            questionCount++;
                            break;
                        case 5:
                            mainText.text = "15 / 3";
                            answer = 5;
                            questionCount = 0;
                            break;
                    }

                    inBossFight = true;

                    npcNameText.text = "Mr. Magma Boss :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Boss_Magma", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/Boss_Magma") as RuntimeAnimatorController;
                    npcImage.GetComponent<SpriteRenderer>().flipX = true;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX - 5, posY - 12, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(35, 35, 25);
                    break;
                case Encounter.Pierate1:
                    mainText.text = "Arrr. What is 2 times the amount of toes on your shoes?";
                    answer = 20;

                    npcNameText.text = "Mr. Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Pierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_Pierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Pierate2:
                    mainText.text = "If I have 4 sacks of meat and I give them equally to 2 of me mates, how many will they each have?";
                    answer = 2;

                    npcNameText.text = "Mr. Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Pierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_Pierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Ghost_Pierate1:
                    mainText.text = "If you had one spirit and someone took that spirit away, how many spirits would you have?";
                    answer = 0;

                    npcNameText.text = "Mr. Ghost Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Ghostpierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_GhostPierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Ghost_Pierate2:
                    mainText.text = "Boo! hahahaha....what is 22 - 5?";
                    answer = 17;

                    npcNameText.text = "Mr. Ghost Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Ghostpierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_GhostPierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Ghost_Pierate3:
                    mainText.text = "What a Boo-tiful evening. I just cant seem to count how many moons there are, could you help me?";
                    answer = 1;

                    npcNameText.text = "Mr. Ghost Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Ghostpierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_GhostPierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Boss_Pierate:
                    switch (questionCount)
                    {
                        case 1:
                            mainText.text = "What is 20 divided by 10?!";
                            answer = 2;
                            questionCount++;
                            break;
                        case 2:
                            mainText.text = "2 x 5?";
                            answer = 10;
                            questionCount++;
                            break;
                        case 3:
                            mainText.text = "21 - 6?";
                            answer = 15;
                            questionCount++;
                            break;
                        case 4:
                            mainText.text = "How many legs do I have?";
                            answer = 2;
                            questionCount++;
                            break;
                        case 5:
                            mainText.text = "How many toes in your shoes?!";
                            answer = 10;
                            questionCount = 0;
                            break;
                    }

                    inBossFight = true;

                    npcNameText.text = "Mr. Pierate Boss :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Pierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/Boss_Pierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<SpriteRenderer>().flipX = false;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Boss_GhostPierate:
                    switch (questionCount)
                    {
                        case 1:
                            mainText.text = "Ive been trying to solve this for years. What is 3 x 4? ";
                            answer = 12;
                            questionCount++;
                            break;
                        case 2:
                            mainText.text = "2 x 5?";
                            answer = 10;
                            questionCount++;
                            break;
                        case 3:
                            mainText.text = "3 x 7?";
                            answer = 21;
                            questionCount++;
                            break;
                        case 4:
                            mainText.text = "How many legs do I have?";
                            answer = 0;
                            questionCount++;
                            break;
                        case 5:
                            mainText.text = "Ive been gone so long I cant seem to remember how many hours are in a day. do you know?";
                            answer = 24;
                            questionCount = 0;
                            break;
                    }

                    inBossFight = true;

                    npcNameText.text = "Mr. Ghost Pierate Boss :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("GhostPierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/Boss_GhostPierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<SpriteRenderer>().flipX = false;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Lone_Pierate1:
                    mainText.text = "Arr, matey, ye shivers me timbers! If it is 10 o'clock and I ask you to meet me in 2 hours, what time should you meet me?";
                    answer = 12;

                    npcNameText.text = "Mr. Lone Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Pierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_Pierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                case Encounter.Lone_Pierate2:
                    mainText.text = "If I have 4 pierate ships and 1 gets bombed, how many pierate ships do I have left?";
                    answer = 2;

                    npcNameText.text = "Mr. Lone Pierate :";
                    npcImage.GetComponent<SpriteRenderer>().sprite = Resources.Load("Pierate", typeof(Sprite)) as Sprite;
                    npcImage.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Controllers/NPC_Pierate") as RuntimeAnimatorController;
                    npcImage.GetComponent<Transform>().localPosition = new Vector3(posX + 8, posY + 17, posZ);
                    npcImage.GetComponent<Transform>().localScale = new Vector3(60, 60, 25);
                    break;
                default:
                    break;
            }
        }
    }

    public static void HideBox()
    {
        boxShown = false;

        inputField.text = "";

        dialogueBox.SetActive(false);
    }
}

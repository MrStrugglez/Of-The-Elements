using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dans_Amore_exit : MonoBehaviour
{

    public static bool tempcheck = false;

    private Mustachio MrM;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Mr_Beardly_Dialogue_Default.NPCCheck)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (!Mr_Beardly_Dialogue_Default.PlayerExitInteraction)
        {
            Mr_Beardly_Dialogue_Default.PlayerExitInteraction = true;
            Top_Player.iscontrallable = false;
        }
        else if (Mr_Beardly_Dialogue_Default.PlayerExitInteraction && tempcheck == true)
        {
            Top_Player.iscontrallable = true;
            tempcheck = false;

            Mustachio_Text.ChangeMustachioText("Hallooooo. I’m in your mind. Isn’t that crazy! Anyway, perhaps there is someone in the village who needs help?");

            StartCoroutine(DisableMustachioText());
        }
        else if (Mr_ONeely.NPCCheck == true && Constable_Jeffry_Dialogue.NPCCheck == true && Lady_Emily_Dialogue.NPCCheck == true && Mr_Poppysock_Dialogue.NPCCheck == true && Mrs_AppleCrown.NPCCheck == true)
        {
            Top_Player.iscontrallable = false;
            Mr_Beardly_Dialogue_Default.PlayerExitInteraction2 = true;
        }
        else if (!Mr_Beardly_Dialogue_Default.PlayerExitInteraction2)
        {
            Mustachio_Text.ChangeMustachioText("Hallooooo. I’m in your mind. Isn’t that crazy! Anyway, perhaps there is someone in the village who needs help?");

            StartCoroutine(DisableMustachioText());
        }
    }

    IEnumerator DisableMustachioText()
    {
        yield return new WaitForSeconds(5);

        Mustachio_Text.EnableMustachioText(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    void Start()
    {
        MrM = FindObjectOfType<Mustachio>();
    }
}

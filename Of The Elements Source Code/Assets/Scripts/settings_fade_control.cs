using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class settings_fade_control : MonoBehaviour {

    public GameObject menu;
    public GameObject settings;
    public VideoPlayer player;
    public VideoClip clip;
    public CanvasGroup background;

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        
        StartCoroutine(AddAlpha());
        
        StartCoroutine(waitBack());
    }


    IEnumerator waitBack()
    {
        float waitTime = 0.6f;
        yield return new WaitForSeconds(waitTime);
        background.alpha = 1;
        player.clip = clip;
        player.Prepare();
        
    }
    IEnumerator AddAlpha()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();

        while (group.alpha < 1)
        {
            group.alpha += Time.deltaTime / 1;
            yield return null;
        }
        group.interactable = true;
        yield return null;

        
    }

    public void FadeOut()
    {

        StartCoroutine(LessAlpha());

        StartCoroutine(Wait());

        StartCoroutine(waitBackground());

        StartCoroutine(WaitMenu());
    }

    IEnumerator waitBackground()
    {
        
        float waitTime = 0.5f;
        yield return new WaitForSeconds(waitTime);
        background.alpha = 0;
    }
    IEnumerator LessAlpha()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();

        while (group.alpha > 0)
        {
            group.alpha -= Time.deltaTime / 1;
            group.alpha -= Time.deltaTime / 1;
            yield return null;
        }
        group.interactable = false;
        yield return null;
    }

    IEnumerator Wait()
    {
        float waitTime = 0.3f;
        yield return new WaitForSeconds(waitTime);
        
        player.Play();
        
    }

    IEnumerator WaitMenu()
    {
        float waitTime = 1.3f;
        yield return new WaitForSeconds(waitTime);
        menu.SetActive(true);
        settings.SetActive(false);
        
    }

    // Update is called once per frame
    void Update () {

                 
	}
}

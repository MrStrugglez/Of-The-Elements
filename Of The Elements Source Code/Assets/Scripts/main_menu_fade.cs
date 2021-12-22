using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class main_menu_fade : MonoBehaviour {

    public GameObject settings;
    public GameObject menu;
    public VideoPlayer player;
    public VideoPlayer cutPlayer;
    public GameObject cutManager;
    public VideoClip clip;
    public CanvasGroup background;
    public Image scene;
    public Sprite pic;
    public GameObject skipButton;

    public VideoClip cutScene;
    public CanvasGroup userDetails;
    public AudioSource music;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.272f);
        }
        StartCoroutine(AddAlpha());
        StartCoroutine(AddUserAlpha());
    }

    IEnumerator AddUserAlpha()
    {
        float waitTime = 1.3f;
        yield return new WaitForSeconds(waitTime);

        while (userDetails.alpha < 1)
        {
            userDetails.alpha += Time.deltaTime / 1;
            userDetails.alpha += Time.deltaTime / 1;
            yield return null;
        }
    }
    IEnumerator AddAlpha()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();
        float waitTime = 0.6f;
        yield return new WaitForSeconds(waitTime);

        while (group.alpha < 1)
        {
            group.alpha += Time.deltaTime / 1;
            yield return null;
        }
        group.interactable = true;
        yield return null;

        scene.sprite = pic;
        background.alpha = 1;

        player.clip = clip;
        player.Prepare();
    }

    public void FadeOut()
    {
        StartCoroutine(LessAlpha());
        StartCoroutine(fadeBackground());
        player.Play();

        StartCoroutine(Wait());
    }

    IEnumerator fadeBackground()
    {
        while (background.alpha > 0)
        {
            background.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        yield return null;
    }


    IEnumerator LessAlpha()
    {
        
        CanvasGroup group = GetComponent<CanvasGroup>();

        while (group.alpha > 0)
        {
            group.alpha -= Time.deltaTime / 1;
            userDetails.alpha -= Time.deltaTime / 1;
            yield return null;
        }
        group.interactable = false;
        
        yield return null;
    }

    IEnumerator Wait()
    {
        float waitTime = 1.3f;
        yield return new WaitForSeconds(waitTime);

        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void PlayCutscene()
    {
        cutManager.SetActive(true);
        skipButton.SetActive(true);
        CanvasGroup group = GetComponent<CanvasGroup>();

        scene.color = Color.black;
        group.alpha = 0;
        userDetails.alpha = 0;
        group.interactable = false;

        cutPlayer.clip = cutScene;
        cutPlayer.Prepare();

        StartCoroutine(fadeFromBlack());
        StartCoroutine(fadeMusic());
    }

    IEnumerator fadeFromBlack()
    {
        float waitTime = 1f;
        yield return new WaitForSeconds(waitTime);
        cutPlayer.Play();
        while (background.alpha > 0)
        {
            background.alpha -= Time.deltaTime / 1;
            yield return null;
        }
        
        yield return null;
    }

    IEnumerator fadeMusic()
    {
        while (music.volume > 0)
        {
            music.volume -= Time.deltaTime / 2;
            yield return null;
        }
        yield return null;

    }
    void Update () {
        
    }
}

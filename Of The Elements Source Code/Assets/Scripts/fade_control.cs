using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;
using BusinessLogic;

public class fade_control : MonoBehaviour {

    public InputField username;
    public InputField password;
    public VideoPlayer player;

    public GameObject loginForm;
    private menu_buttons_control control;

    private User user;
    public void LoginFadeOut()
    {
        control = loginForm.GetComponent<menu_buttons_control>();
        user = control.user;

        if (user.UserId != 123456 && user.Grade != 'Z')
        {
            StartCoroutine(Vanish());
            Debug.Log("Image fading");
        }
    }

	public void FadeOut()
    {
        StartCoroutine(LessAlpha());
    }

    public void FadeIn()
    {
        StartCoroutine(AddAlpha());
    }

    IEnumerator Vanish()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();
        
        player.Play();

        float timer = 0.3f;
        yield return new WaitForSeconds(timer);
        group.alpha = 0;
        Debug.Log("Video Playing");

        group.interactable = false;

        while (player.isPlaying != true)
        {
            Debug.Log("Video is playing");
        }
        yield return null;
    }

    IEnumerator LessAlpha()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();


        while (group.alpha > 0)
        {
            group.alpha -= Time.deltaTime / 1;
            yield return null;
        }
        player.Play();
        Debug.Log("Video Playing");

        group.interactable = false;
        yield return null;
    }

    IEnumerator AddAlpha()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();

        while (group.alpha < 1)
        {
            group.alpha += Time.deltaTime / 2;
            yield return null;
        }
        group.interactable = false;
        yield return null;
    }
}

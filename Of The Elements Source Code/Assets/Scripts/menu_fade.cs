using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using BusinessLogic;

public class menu_fade : MonoBehaviour {

    public GameObject login;
    public GameObject main;
    public InputField username;
    public InputField password;
    public VideoPlayer player;

    private menu_buttons_control control;
    private User user;

    private void Start()
    {
    }

    public void FadeOut()
    {
        control = login.GetComponent<menu_buttons_control>();
        user = control.user;
        if (user.UserId != 123456 && user.Grade != 'Z')
        {
            StartCoroutine(LessAlpha());
        }

    }

    IEnumerator LessAlpha()
    {
        CanvasGroup menu = GetComponent<CanvasGroup>();

        while (menu.alpha > 0)
        {
            menu.alpha -= Time.deltaTime / 1;
            menu.alpha -= Time.deltaTime / 1;
            yield return null;
        }

        menu.interactable = false;
        login.SetActive(false);
        main.SetActive(true);
        yield return null;
    }
}

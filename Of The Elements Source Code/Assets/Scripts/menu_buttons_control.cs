using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BusinessLogic;
using DataAccess;
using System;
using UnityEngine.Video;
using TMPro;

public class menu_buttons_control : MonoBehaviour {

    public InputField username;
    public InputField password;
    public GameObject popup;
    public User user;
    public Canvas background;
    public VideoPlayer player;

    public TextMeshProUGUI txtUsername;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtLevel;
    public TextMeshProUGUI txtGrade;

    public Camera cam;

    public void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.DeleteKey("volume");
        }
        cam.aspect = 4f / 3f;
        Application.runInBackground = true;
        player.Prepare();
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void Login()
    {
        StartCoroutine(checkDatabase());

        user = BusinessLogic.User.Login(username.text, password.text);
        Debug.Log("Logged in");
        Debug.Log(user.UserId);

        if (user.UserId != 123456 && user.Grade != 'Z')
        {
            txtUsername.text = user.Username;
            txtName.text = user.Name.Substring(0, 1) + ". " + user.Surname;
            txtLevel.text = "Level " + user.Curr_level;
            txtGrade.text = "Grade " + Convert.ToInt32(user.Grade);
        }
        else
        {
            popup.SetActive(true);

        }
    }

    IEnumerator checkDatabase()
    {
        Debug.Log("Loading...");
        yield return null;
    }
}

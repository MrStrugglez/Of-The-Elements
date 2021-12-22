using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_menu_control : MonoBehaviour {

	public static bool gamePause;
    public GameObject pauseMenu;
    public Slider volumeControl;
    public GameObject askQuit;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        volumeControl.value = PlayerPrefs.GetFloat("volume");
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        volumeControl.interactable = true;
        

    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void Quit()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }

    public void ChangeVolume()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        AudioSource music = objs[0].GetComponent<AudioSource>();
        Debug.Log(music.volume);
        music.volume = volumeControl.value;
    }

    public void AskQuit()
    {
        askQuit.SetActive(true);
    }

    public void CancelQuit()
    {
        askQuit.SetActive(false);
    }
}

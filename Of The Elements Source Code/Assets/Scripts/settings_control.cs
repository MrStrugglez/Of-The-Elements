using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class settings_control : MonoBehaviour {

    Resolution[] rez;
    public Dropdown drpRez;
    public Slider volumeControl;
    public AudioSource audioPlayer;



    public void SetQuality(int quIndex) {

        QualitySettings.SetQualityLevel(quIndex);

    }

    public void SetFullscreen(bool full)
    {
        Screen.fullScreen = false;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = rez[index];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
    
    void Start()
    {
        rez = Screen.resolutions;
        drpRez.ClearOptions();

        List<string> options = new List<string>();

        int currRezIndex = 0;
        for (int i = 0; i < rez.Length; i++)
        {
            string option =rez[i].width  + "x" + rez[i].height;
            options.Add(option);

            if (rez[i].width == Screen.currentResolution.width && rez[i].height == Screen.currentResolution.height)
            {
                currRezIndex = i;
            }
        }

        drpRez.AddOptions(options);
        drpRez.value = currRezIndex;
        drpRez.RefreshShownValue();
    }

    public void ChangeVolume()
    {
        audioPlayer.volume = volumeControl.value;
        PlayerPrefs.SetFloat("volume", volumeControl.value);
        //volume.text = (volumeControl.value*100).ToString();
    }

}

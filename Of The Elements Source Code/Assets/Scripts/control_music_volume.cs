using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class control_music_volume : MonoBehaviour {

    public Slider volumeControl;
    public AudioSource audioPlayer;


    private void Update()
    {
        audioPlayer.volume = volumeControl.value;
        //volume.text = (volumeControl.value*100).ToString();
    }
}

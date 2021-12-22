using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_control : MonoBehaviour {

    public KeyCode click;
    public KeyCode space;
    public VideoPlayer player;
    public GameObject obj;
    public Slider loading;
    public GameObject loadingScreen;

    private int stopCount = 0;
    private int count = 0;
    private float speed = 3.5f;

    private int[] stopFrames = new int[] { 70, 110, 153, 196, 239, 282, 325, 368, 411, 453 };
    void Start () {

        //StartCoroutine(StopBook());
    }

    IEnumerator StopBook()
    {
        float timer = 4.5f;
        yield return new WaitForSeconds(timer);
        player.Pause();
    }
	
	// Update is called once per frame
	void Update () {

        //if (player.isPlaying && player.playbackSpeed == speed)
        //{
        //    if (player.frame == stopFrames[stopCount - 1])
        //    {
        //        player.playbackSpeed = 1;
        //        player.Pause();
        //    }
        //}

        if (stopCount < 10)
        {
            if (player.frame == stopFrames[stopCount])
            {
                player.playbackSpeed = 1;
                player.Pause();
                stopCount++;
            }
        }

        

        if (Input.GetKeyDown(click) || Input.GetKeyDown(space))
        {
            if (player.frame >= stopFrames[0])
            {
                if (!player.isPlaying)
                {
                    if (stopCount < 10)
                    {
                        player.playbackSpeed = 1;
                        player.frame = stopFrames[stopCount - 1] + 1;
                        player.Play();
                    }
                    else
                    {
                        //obj.SetActive(false);
                        Debug.Log("Moving to game...");

                        StartCoroutine(LoadScene());

                        //move to game
                    }
                }
                    
                
            }
            
            
            
        }
	}

    public void Skip()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Section1_0");
        loadingScreen.SetActive(true);


        while (!operation.isDone && count < 110)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            Debug.Log("Loading progress" + progress);
            loading.value = progress;

            count++;
            yield return null;
        }
        
    }
}

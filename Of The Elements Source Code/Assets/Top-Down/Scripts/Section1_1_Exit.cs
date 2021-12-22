using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Section1_1_Exit : MonoBehaviour
{
    [SerializeField]
    Image dragon;

    public static bool showdragon = false;

    void Update()
    {
        if (showdragon)
        {
            dragon.CrossFadeAlpha(1, 0.5f, false);

            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        dragon.canvasRenderer.SetAlpha(0.0f);
    }
}

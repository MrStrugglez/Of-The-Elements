using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mustachio : MonoBehaviour
{
    private float time = 0;
    private bool delay = false;

    [SerializeField]
    private GameObject mustachiosbox, mustachioface;

    [SerializeField]
    private Text MustachioText = null;

    void Start()
    {
        HideMustachio();
    }

    void Update()
    {
        if ((Time.time * 1000) >= time && delay == true)
        {
            delay = false;
            HideMustachio();
        }
    }

    public void ShowMustachio(string Text)
    {
        mustachiosbox.SetActive(true);
        mustachioface.SetActive(true);
        MustachioText.text = Text;
        time = (Time.time * 1000) + 10000;
        delay = true;
    }

    public void HideMustachio()
    {
        mustachiosbox.SetActive(false);
        mustachioface.SetActive(false);
    }
}

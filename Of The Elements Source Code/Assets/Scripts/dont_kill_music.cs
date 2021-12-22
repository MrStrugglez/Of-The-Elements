using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont_kill_music : MonoBehaviour {

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

}

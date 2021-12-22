using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup_enter_control : MonoBehaviour {

    public KeyCode enter;
    public Button ok;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enter))
        {
            ok.onClick.Invoke();
        }
    }
}

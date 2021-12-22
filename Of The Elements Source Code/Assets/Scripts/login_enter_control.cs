using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login_enter_control : MonoBehaviour {

    public KeyCode enter;
    public Button login;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(enter))
        {
            login.onClick.Invoke();
            
        }
	}
}

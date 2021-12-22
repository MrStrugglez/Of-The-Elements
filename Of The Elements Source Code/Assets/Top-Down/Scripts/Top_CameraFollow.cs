using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_CameraFollow : MonoBehaviour
{

    private Transform Target;

    void Start ()
    {
        Target = GameObject.Find("Player").transform;
	}
	
	void LateUpdate ()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
	}
}

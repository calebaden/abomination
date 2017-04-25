using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour {
    
    public bool wheelSide;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (wheelSide)
        {
            transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (!wheelSide)
        {
            transform.Rotate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
	}
}

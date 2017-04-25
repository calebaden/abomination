using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRain : MonoBehaviour {

    public GameObject rainFX;

	// Use this for initialization
	void Start ()
    {
        rainFX.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.transform.tag == "Player")
        {
            rainFX.SetActive(true);
        }
    }
}

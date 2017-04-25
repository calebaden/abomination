using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScroll : MonoBehaviour {

    // VARIABLES AND CONSTANTS.
    public float speed;
    public float duration;
    public Vector3 direction;

    float elapsedTime = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (elapsedTime < duration)
        {
            // Debug.Log("Test");
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime > duration)
        {
            speed = 0.0f;
        }

    }
}

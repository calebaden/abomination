using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {

    // VARIABLES AND CONSTANTS.
    public float duration = 2.0f;
    public float elapsedTime = 0.0f;
    public SpriteRenderer BlinkText;

    // Use this for initialization
    void Start () {
        BlinkText = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        BlinkText.enabled = true;

        if ((elapsedTime < duration) & (elapsedTime < 1)) 
        {
            BlinkText.enabled = false;
            elapsedTime += Time.deltaTime;
        }

        if ((elapsedTime < duration) & (elapsedTime > 1))
        {
            BlinkText.enabled = true;
            elapsedTime += Time.deltaTime;
        }

        else if (elapsedTime > duration)
        {
            elapsedTime = 0.0f;
            BlinkText.enabled = false;
        }
    }

}
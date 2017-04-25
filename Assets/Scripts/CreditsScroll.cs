using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour {

    // VARIABLES AND CONSTANTS.
    public float speed;
    public float duration = 18.0f;
    public Vector3 direction;

    float elapsedTime = 999.99f;
    public GameObject CreditsObject;

    // Update is called once per frame
    void Update () {

        if (elapsedTime < duration) {

            speed = 62.0f;
            CreditsObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime > duration) {

            speed = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Player") {

            Debug.Log(collision.gameObject.tag);
            elapsedTime = 0.0f;
        }
    }
}

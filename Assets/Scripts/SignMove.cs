using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignMove : MonoBehaviour {

    // VARIABLES AND CONSTANTS.
    public float speed = 2.0f;
    Transform myTransform;
    public float minX = -16f;

    void Start() {

        myTransform = transform;
    }

    void FixedUpdate() {

        myTransform.localPosition += Vector3.left * speed * Time.fixedDeltaTime;

        if (myTransform.position.x < minX) {

            Destroy(gameObject);
        }
    }
}

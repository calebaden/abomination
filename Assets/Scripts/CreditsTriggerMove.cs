using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTriggerMove : MonoBehaviour {

    // VARIABLES AND CONSTANTS.
    float speed;
    Transform myTransform;
    public float minX = -16f;

    void Start() {

        speed = GameManager.instance.blockSpeed;
        myTransform = transform;
    }

    void FixedUpdate() {

        myTransform.localPosition += Vector3.left * speed * Time.fixedDeltaTime;
    }
}

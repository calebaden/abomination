using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgroundScroll : MonoBehaviour {

    public float speed;
    public float loopspot = 16f;
    Transform myTransform;

    void Start () {
        myTransform = transform;
    }

    void FixedUpdate () {
        myTransform.position += Vector3.left * speed * Time.fixedDeltaTime;
        if (myTransform.position.x < -loopspot)
        {
            myTransform.position += Vector3.right * loopspot * 2;
        }
    }
}

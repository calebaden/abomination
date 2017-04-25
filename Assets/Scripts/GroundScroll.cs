using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour {

    float speed;
    Renderer myRenderer;

    void Start () {
        speed = GameManager.instance.blockSpeed;
        myRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate () {
        myRenderer.material.mainTextureOffset += Vector2.right * speed * Time.fixedDeltaTime;
    }
}

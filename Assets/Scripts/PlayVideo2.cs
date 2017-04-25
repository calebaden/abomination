using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayVideo2 : MonoBehaviour {

    WebGLMovieTexture tex2;
    public string videoPath2;

    void Awake() {
        tex2 = new WebGLMovieTexture(videoPath2);
        gameObject.GetComponent<MeshRenderer>().material.mainTexture = tex2;
    }

    void Start() {
        StartCoroutine(WaitToPlay());
    }

    IEnumerator WaitToPlay() {
        print(Time.time);
        yield return new WaitForSeconds(147);
        tex2.Play();
        print(Time.time);
    }

    void Update() {
        tex2.Update();
    }
}

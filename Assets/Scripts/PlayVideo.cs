using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayVideo : MonoBehaviour {

    public WebGLMovieTexture tex;
    public string videoPath;

    public void Awake () {
        tex = new WebGLMovieTexture(videoPath);
        gameObject.GetComponent<MeshRenderer>().material.mainTexture = tex;
    }

    public void Start () {
        StartCoroutine(WaitToPlay());
    }

    IEnumerator WaitToPlay () {
        print(Time.time);
        yield return new WaitForSeconds(58); // Will update wait time to 58 seconds later, set to 2 seconds for testing.
        tex.Play();
        print(Time.time);
    }

    public void Update () {
        tex.Update();
    }

    public void OnPause () {
        tex.Pause();
    }

    public void OnUnPause () {
        tex.Play();
    }
}
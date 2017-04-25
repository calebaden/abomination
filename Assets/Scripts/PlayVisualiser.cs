using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayVisualiser : MonoBehaviour {

    public WebGLMovieTexture visualiser;
    public string videoPath;

    public void Awake() {
        visualiser = new WebGLMovieTexture(videoPath);
        gameObject.GetComponent<MeshRenderer>().material.mainTexture = visualiser;
    }

    public void Start() {
        //StartCoroutine(WaitToPlay());
        visualiser.Play();
    }

    //IEnumerator WaitToPlay() {
    //    yield return new WaitForSeconds(0);
        
    //}

    public void Update() {
        visualiser.Update();
    }

    public void OnPause() {
        visualiser.Pause();
    }

    public void OnUnPause() {
        visualiser.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour {

    public float startTime;
    public float duration;
    public GameObject anim;

	void Start () {
        duration += startTime;
	}
	
	void Update () {
		if (Time.time > startTime) {
            anim.SetActive(true);
        }
        if (Time.time > duration) {
            Destroy(gameObject);
        }
	}
}

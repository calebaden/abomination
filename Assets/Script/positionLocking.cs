using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionLocking : MonoBehaviour {
    public GameObject parent;
    public float xmove;
    public float ymove;
    public float zmove;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = parent.transform.position;
        newPos.x += xmove;
        newPos.y += ymove;
        newPos.z += zmove;
        transform.position = newPos;
	}
}

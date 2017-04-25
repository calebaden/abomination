using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public GameObject pivot;
    public float speed;
    public Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = pivot.transform.position + new Vector3(0,0.5f,1.5f);
        transform.rotation = pivot.transform.rotation;
        PlayerControls();
	}

    public void PlayerControls()
    {
        while (Input.GetKeyDown("w"))
        {
            Debug.Log("GOING");
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
    }
}

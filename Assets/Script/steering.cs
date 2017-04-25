using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering : MonoBehaviour {
    public float cameraBias = .96f;
    public float carSmoothing;
    public float steeringSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 newPos = transform.localPosition;
            if (newPos.x < 2.5f)
                newPos.x -= Input.GetAxis("Horizontal") * steeringSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, carSmoothing * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") >0)
        {
            Vector3 newPos = transform.localPosition;
            if(newPos.x >-2.5f)
            newPos.x -= Input.GetAxis("Horizontal") * steeringSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, carSmoothing * Time.deltaTime);
        }


        //Vector3 clampedPosition = transform.localPosition;
        //clampedPosition.x = Mathf.Clamp(transform.localPosition.x, -3.0f, 3.0f);
        //transform.localPosition = clampedPosition;

        //transform.position = transform.position - (transform.right * Input.GetAxis("Horizontal")) * steeringSpeed;

        Vector3 moveCam = transform.position + transform.forward * 8.0f + Vector3.up * 2.5f;
        Camera.main.transform.position = Camera.main.transform.position * cameraBias + moveCam * (1.0f - cameraBias);
        Camera.main.transform.LookAt(transform.position + -transform.forward * 30.0f);

    }
}

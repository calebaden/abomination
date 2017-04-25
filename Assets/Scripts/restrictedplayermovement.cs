using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restrictedplayermovement : MonoBehaviour {



    public Animator thisanim;

    public GameObject daddy;
    public GameObject mommy;

    private float tunspeed;


    public float cameraBias = .96f;
    public float carSmoothing;
    public float steeringSpeed;

   // private Vector3 newrot;
   


    // Use this for initialization
    void Start () {
      //  newrot = new Vector3(0, 25, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 newPos = transform.localPosition;
            if (newPos.x < 3.5f)
                newPos.x -= Input.GetAxis("Horizontal") * steeringSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, carSmoothing * Time.deltaTime);

            if (transform.rotation.y <= 25)
                transform.Rotate(-Vector3.up * Time.deltaTime * 18);


        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 newPos = transform.localPosition;
            if (newPos.x > -3.5f)
                newPos.x -= Input.GetAxis("Horizontal") * steeringSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, carSmoothing * Time.deltaTime);


            if (transform.rotation.y >= -25)
                transform.Rotate(Vector3.up * Time.deltaTime * 18);


        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            thisanim.speed = 1.8f;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            thisanim.speed = 1f;
        }


        Vector3 moveCam = transform.position - transform.forward * 5.0f + Vector3.up * 3f;
        Camera.main.transform.position = Camera.main.transform.position * cameraBias + moveCam * (1.0f - cameraBias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);

    }



}

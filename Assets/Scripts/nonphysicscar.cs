using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonphysicscar : MonoBehaviour {

    public Rigidbody RB;

    public GameObject backaxel;
    public Rigidbody BRB;

    private float AngularSpeed;
    private float MoveSpeed = 5;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        drive();
        turn();
	}

    void drive()
    {
        RB.velocity = transform.forward * MoveSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveSpeed = 10;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            MoveSpeed = 5;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveSpeed = 2;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveSpeed = 5;
        }
    }


    void turn()
    {
        AngularSpeed = Input.GetAxis("Horizontal");


        Quaternion deltaAngle =
        Quaternion.AngleAxis(Mathf.Rad2Deg * AngularSpeed * Time.deltaTime, transform.up);
        transform.Rotate(deltaAngle.eulerAngles);

        Vector3 v = RB.velocity;
        v = deltaAngle * v;
        RB.velocity = v;
    }
}

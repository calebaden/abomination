using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpHeight = 11f;
    Rigidbody2D rb;
    Transform myTransform;

    float startX;
    float bandTime;
    public float rubberbandDelay = 0.6f;
    public float rubberbandSpeed = 2f;
    public float rubberbandGapLength = 5f;
    public AnimationCurve rubberbandCurve;
    public float curveDistance = 3f;

    public float upwardGravityScale = 3f;
    public float fallingGravityScale = 5f;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        myTransform = transform;
        startX = myTransform.position.x;
	}
	
	void Update () {
		if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) {
            RaycastHit2D hit = Physics2D.Raycast(myTransform.position + (Vector3.down * 0.02f), Vector2.down, 0.05f);
            if (hit) {
                rb.velocity = Vector2.up * jumpHeight;
            }
        }

        if (Input.GetKeyUp("space") || Input.GetButtonUp("Fire1")) {
            if (rb.velocity.y > 0) {
                rb.velocity = Vector2.zero;
            }
        }

        if (myTransform.position.x < startX + 0.05f && myTransform.position.x > startX - 0.05f) {
            bandTime = Time.time + rubberbandDelay;
        } else {
            if (Time.time > bandTime) {
                RaycastHit2D hit = Physics2D.Raycast(myTransform.position + (Vector3.up * 0.5f) + (Vector3.right * 0.5f), Vector2.right, rubberbandGapLength);
                if (!hit && rb.velocity.y == 0) {
                    //Debug.Log((startX - myTransform.position.x) / curveDistance);
                    myTransform.position += Vector3.right * rubberbandSpeed * Time.deltaTime * rubberbandCurve.Evaluate (1 - ((startX - myTransform.position.x) / curveDistance));
                }
            }
        }

        if (rb.velocity.y > 0) {
            rb.gravityScale = upwardGravityScale;
        } else {
            rb.gravityScale = fallingGravityScale;
        }

        //Debug.DrawRay(myTransform.position + (Vector3.up * 0.5f) + (Vector3.right * 0.5f), Vector2.right * rubberbandGapLength, Color.green, 0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // prepare the timing data
    public int gameDuration = 180; //Seconds
    public float gameRunTime;
    public int speedMultiplier;

    public float lerpPosition;
    public float lerpPositionDelta;


    //Prepare the location data
    public Transform startPositionTransform;
    public Transform endPositionTransform;
    public Transform playerTransform;

	// Use this for initialization
	void Start ()
    {
        gameRunTime = gameDuration;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    public void UpdateCameraPosition()
    {
        gameRunTime -= (Time.fixedDeltaTime + lerpPositionDelta);

        // Calculate lerp Position = current time - deltaTime * positionalDelta
        lerpPosition = gameRunTime / gameDuration;

        // lerp the player's position between the start and end
        float newTransformY = Mathf.Lerp(startPositionTransform.position.y, endPositionTransform.position.y, 1 - lerpPosition);

        playerTransform.Translate(new Vector3(playerTransform.position.x, newTransformY, playerTransform.position.z));

        //Debug.Log("Transformed the player by " + newTransformY + " Units. Player is: " + lerpPosition + "% complete");

    }
}

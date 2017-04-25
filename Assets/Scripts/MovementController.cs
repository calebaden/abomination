using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class MovementController : MonoBehaviour {

    public AudioSource endgameImpact;

    public MainMenuUI mainMenuUI;
    public CameraRotate camRot;
    public EndGame endGame;
    public GameObject cam;
	public float timeFalling;

    public float movementClampX;
    public float movementClampY;
    public Vector2 originPosition;

    public Vector3 startPosition;
    public Vector3 endPosition;

    public Vector3 horizontalPosition;

    public float total;
    public float speed;
    public float songLength;

    public float horizontalSpeed_X = 1f;
    public float horizontalSpeed_Z = 1f;

    public GameObject playerPivot;

    public Transform playerRotStartMarker;
    public Transform playerRotEndMarker;
    public float playerRotSpeed = 0.25F;
    private float playerRotStartTime;
    private float playerRotJourneyLength;

    public ColorCorrectionCurves colourCorrectionCurve;

    public void Awake()
    {
        total = Mathf.Abs(endPosition.y - startPosition.y);

        speed = total / songLength;
    }
    

	// Use this for initialization
	void Start ()
    {
        mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<MainMenuUI>();
        camRot = GameObject.FindGameObjectWithTag("CameraRotation").GetComponent<CameraRotate>();
       // endGame = GameObject.FindGameObjectWithTag("EndGame").GetComponent<EndGame>();

        originPosition = new Vector2(transform.position.x, transform.position.y);

        camRot.enabled = false;

        playerRotStartTime = Time.time;
        playerRotJourneyLength = Quaternion.Angle(playerRotStartMarker.rotation, playerRotEndMarker.rotation);

        colourCorrectionCurve = GetComponentInChildren<ColorCorrectionCurves>();
        
    }

    // Update is called once per frame
    public void Update ()
    {

        float horizontalPositionX = transform.position.x + (Input.GetAxis("Horizontal") * horizontalSpeed_X * Time.deltaTime);
        float horizontalPositionY = transform.position.z + (Input.GetAxis("Vertical") * horizontalSpeed_Z * Time.deltaTime);

        horizontalPositionX = Mathf.Clamp(horizontalPositionX, -movementClampX, movementClampX);
        horizontalPositionY = Mathf.Clamp(horizontalPositionY, -movementClampY, movementClampY);

        horizontalPosition = new Vector3(horizontalPositionX - startPosition.x, 0, horizontalPositionY - startPosition.z);

        if (mainMenuUI.gameStarted == true)
        {
            Movement();            
            camRot.enabled = true;
            cam.GetComponent<Raycasting>().enabled = true;

            //transform.rotation = Quaternion.Euler(90, 0, 0);

            float distCovered = (Time.time - playerRotStartTime) * playerRotSpeed;
            float fracJourney = distCovered / playerRotJourneyLength;
            transform.rotation = Quaternion.Lerp(playerRotStartMarker.rotation, playerRotEndMarker.rotation, fracJourney);
        }     
    }

    void Movement()
    {
        timeFalling += Time.deltaTime;

        colourCorrectionCurve.saturation = 1 - (timeFalling / songLength);

        // Vertical Movement
        float verticalDeltaPosition = speed * (timeFalling);

        Vector3 newPosition = startPosition + new Vector3(0, -verticalDeltaPosition, 0) + horizontalPosition;

        transform.position = newPosition;


    }
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.transform.tag == "EndGame")
        {
            endgameImpact.Play();
        }
    }
}

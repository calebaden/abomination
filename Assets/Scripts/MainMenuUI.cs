using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public static MainMenuUI thisMenu;

    public PlayMusic musicPlayer;

    public GameObject mainMenuUI;
    public GameObject creditsUI;
    public GameObject endGameCreditsUI;
    public GameObject howToPlayUI;
    public GameObject uIGroup;

    public Transform uIGroupStartMarker;
    public Transform uIGroupEndMarker;
    public float uIGroupSpeed = 1.0F;
    private float uIGroupStartTime;
    private float uIGroupJourneyLength;

    public bool gameStarted = false;

    void Awake()
    {
        thisMenu = this;
    }

    // Use this for initialization
    void Start ()
    {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<PlayMusic>();
        playGame();
        //uIGroupStartTime = Time.time;
        //uIGroupJourneyLength = Vector3.Distance(uIGroupStartMarker.position, uIGroupEndMarker.position);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //lerpMenuUI();
    }

    void lerpMenuUI()
    {
        //float distCovered = (Time.time - uIGroupStartTime) * uIGroupSpeed;
        //float fracJourney = distCovered / uIGroupJourneyLength;
        //uIGroup.transform.position = Vector3.Lerp(uIGroupStartMarker.position, uIGroupEndMarker.position, fracJourney);       
        
    }

    public void playGame()
    {
        mainMenuUI.SetActive(false);
        gameStarted = true;
        musicPlayer.playMusic();
    }

    public void activateCredits()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void deactivateCredits()
    {
        creditsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void deactivateEndGameCredits()
    {
        endGameCreditsUI.SetActive(false);
        Application.LoadLevel("Test Scene");
    }

    public void activateHowToPlay()
    {
        mainMenuUI.SetActive(false);
        howToPlayUI.SetActive(true);
    }

    public void deactivateHowToPlay()
    {
        howToPlayUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}

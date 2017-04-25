using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {

    public MainMenuUI mainMenuUI;

    AudioSource audioSource;  

    // Use this for initialization
    void Start ()
    {
        mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<MainMenuUI>();

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //playMusic();
	}

    public void playMusic()
    {
        audioSource.Play();        
    }
}

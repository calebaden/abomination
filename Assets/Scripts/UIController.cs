﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int currentScene;
    public float fadeSpeed;
    public float creditsRollSpeed;
    public bool isFaded;
    public bool isCredits;
    public float thanksTimer;

    public Image blackFadeImage;
    public Image gradientBlockImage;
    public Color imageColor;
    public GameObject credits;
    public GameObject creditsRoll;
    public GameObject player;
    Animator playerAnim;

	// Use this for initialization
	void Start ()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
        {
            // do all the main menu start calls
        }
        else if (currentScene == 1)
        {
            // do all the main scene start calls
            blackFadeImage.color = Color.black;
            playerAnim = player.GetComponent<Animator>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (currentScene == 0)
        {
            MainMenuUpdate();
        }
        else if (currentScene == 1)
        {
            MainSceneUpdate();
        }
	}

    // Function that handles all main menu update code
    void MainMenuUpdate ()
    {

    }

    // Function that handles all main scene update code
    void MainSceneUpdate ()
    {
        // When the scene is loaded, decrease the image alpha to 0 at a set speed
        if (!isFaded && blackFadeImage.color.a > 0)
        {
            imageColor.a -= fadeSpeed * Time.deltaTime;
            blackFadeImage.color = imageColor;
        }
        // When arriving at the finish, increase the image alpha to 200 at a set speed
        else if (isFaded && blackFadeImage.color.a < 1)
        {
            imageColor.a += fadeSpeed * Time.deltaTime;
            blackFadeImage.color = imageColor;
            if (playerAnim.speed > 0.1f)
            {
                playerAnim.speed -= fadeSpeed * Time.deltaTime;
            }
        }
        else if (isFaded && blackFadeImage.color.a >= 1)
        {
            if (!credits.activeInHierarchy)
            {
                credits.SetActive(true);
            }
            else
            {
                if (creditsRoll.transform.localPosition.y < 900)
                {
                    creditsRoll.transform.Translate(Vector2.up * creditsRollSpeed * Time.deltaTime);
                }
                else
                {
                    if (thanksTimer > 0)
                    {
                        thanksTimer -= Time.deltaTime;
                    }
                    else
                    {
                        AbominationManager.Instance.CallCoroutine();
                    }
                }
            }
        }
    }

    // When this function is called, load the main scene (index 1)
    public void OnStartClick ()
    {
        SceneManager.LoadScene(1);
    }

    // When this function is called, quit the application (may not work on WebGL)
    public void OnQuitClick ()
    {
        Application.Quit();
    }
}

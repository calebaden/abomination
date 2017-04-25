using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MainMenuUI mainMenuUI;

    // Use this for initialization
    void Start ()
    {
        mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<MainMenuUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (mainMenuUI.gameStarted == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        gameInputs();	
	}

    void gameInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Test Scene");
        }        
    }
}

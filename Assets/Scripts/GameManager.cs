using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MainMenuUI mainMenuUI;
    public static GameManager instance = null;
    public float blockSpeed = 2f;
    public int index;

    void Awake () {

        instance = this;
    }
    // Use this for initialization
    void Start ()
    {
        //mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<MainMenuUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (mainMenuUI.gameStarted == true)
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
        //else
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
	}
}

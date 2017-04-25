using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbominationManager : MonoBehaviour
{
    int currentScene;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
        currentScene = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Loads the next scene in the project
    public void ChangeScene()
    {
        if (currentScene <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public MainMenuUI mainMenuUI;

    public bool gameEnded = false;

    // Use this for initialization
    void Start ()
    {
        mainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<MainMenuUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.transform.tag == "Player")
        {
            AbominationManager.Instance.CallCoroutine();
        }
    }
}

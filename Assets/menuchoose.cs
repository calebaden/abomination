using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuchoose : MonoBehaviour {

   
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void ChooseDrive()
    {
        PlayerPrefs.SetInt("MenuCHoice", 1);
        GetComponent<RetroAesthetics.Demos.MenuScripts>().StartLevel();
    }


    public void ChooseCruise()
    {
        PlayerPrefs.SetInt("MenuCHoice", 2);
        GetComponent<RetroAesthetics.Demos.MenuScripts>().StartLevel();
    }
}

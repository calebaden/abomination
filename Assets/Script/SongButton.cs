using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
    public class SongButton : MonoBehaviour {
    AudioManager SongChanger; 

	// Use this for initialization
	void Start () {
        SongChanger = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void skipButton()
    {
        SongChanger.NewSong();
    }
}

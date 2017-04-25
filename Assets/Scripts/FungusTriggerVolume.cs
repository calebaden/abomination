using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusTriggerVolume : MonoBehaviour {
    public Flowchart levelScripting;

    public string EnterVolumeBlock;
    public string ExitVolumeBlock;

	// Use this for initialization
	void Start () {
        if (levelScripting == null)
            levelScripting = FindObjectOfType<Flowchart>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(!string.IsNullOrEmpty(EnterVolumeBlock))
        {
            levelScripting.ExecuteBlock(EnterVolumeBlock);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(ExitVolumeBlock))
        {
            levelScripting.ExecuteBlock(ExitVolumeBlock);
        }
    }
}

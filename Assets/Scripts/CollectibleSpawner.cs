using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour {

    public Transform[] spawners;

    public GameObject[] collectibles;

    public GameObject collectible;

    public float respawntime;
    private bool hasStartedInvokeRepeating = false;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (hasStartedInvokeRepeating == false)
        {
            OnGameStart();
            hasStartedInvokeRepeating = true;
        }

	}

    void OnGameStart()
    {
        //Runs the spawn function after a certain amount of seconds 
        InvokeRepeating("spawn", respawntime, respawntime);
    }

    void spawn()
    {
        collectible = collectibles[(int)Random.Range(0, collectibles.Length)];
        //selects spawn point from an array 
        Transform spawnPoint = spawners[(int)Random.Range(0, spawners.Length)];
        //spawns prefab
        Instantiate(collectible, spawnPoint.position, Quaternion.Euler(90,0,0));
    }
}

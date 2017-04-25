using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPrefab;
    public GameObject[] whatToSpawnClone;
    public int index;

    void Awake() {

        index = PlayerPrefs.GetInt("Character"); // 0 = AWOL, 1 = HESHER, 2 = JIGGY MIGGY.
    }

    void Start () {

        if (index == 0) {
            SpawnPlayer();
        }
        else if (index == 1) {
            SpawnNewPlayer1();
        }
        else {
            SpawnNewPlayer2();
        }
        
    }

    public void SpawnPlayer() {

        whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }

    public void SpawnNewPlayer1() {

        whatToSpawnClone[1] = Instantiate(whatToSpawnPrefab[1], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void SpawnNewPlayer2() {

        whatToSpawnClone[2] = Instantiate(whatToSpawnPrefab[2], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {
            if (collision.gameObject.name == "Player_AWOL(Clone)") {

                Debug.Log(collision.gameObject.tag);
                Destroy(collision.gameObject);
                SpawnNewPlayer1();
            }
            else if (collision.gameObject.name == "Player_HESHER(Clone)") {
                Debug.Log(collision.gameObject.tag);
                Destroy(collision.gameObject);
                SpawnNewPlayer2();
            }
            else {
                // Else Player Name is Player_JIGGYMIGGY(CLONE).
                Debug.Log(collision.gameObject.tag);
                Destroy(collision.gameObject);
                SpawnPlayer();
            }
        }
    }
}

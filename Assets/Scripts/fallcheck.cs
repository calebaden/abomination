using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallcheck : MonoBehaviour {

   // public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void MakePlayerReset(GameObject Player )
    {
        Player.transform.position = new Vector3(0, 0, 0);
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        Player.GetComponent<Rigidbody>().velocity = new Vector3( 0,0,0);
        //StopAllCoroutines();
        //StartCoroutine(playerLerp(Player.transform.position, Player.transform.rotation));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            MakePlayerReset(other.gameObject);
        }
    }


    IEnumerator playerLerp(Vector3 playerpos, Quaternion playerrot, GameObject _player)
    {
        Vector3 playerend = new Vector3(0, 1, 0);
        Quaternion rotend = Quaternion.Euler(0, 0, 0);
        while (playerpos != playerend)
        {
            _player.transform.position = Vector3.Lerp(playerpos, playerend, 1 * Time.deltaTime);

            while (playerrot != rotend)
            {
                _player.transform.rotation = Quaternion.Lerp(playerrot, rotend, 1 * Time.deltaTime);
            }
        }

     
        yield return null;
    }
}

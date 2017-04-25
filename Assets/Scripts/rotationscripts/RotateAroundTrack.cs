using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTrack : MonoBehaviour {

    public static RotateAroundTrack Instance;

    public GameObject[] objstoRot;

    private float rotationspeed;

    public bool rotate = false;
    private float rottaroundtrackstart = 8.9f;

    void Start ()
    {
        Instance = this;
        rotationspeed = Random.Range(16, 22);
	}
	
	void Update ()
    {
        rottaroundtrackstart -= Time.deltaTime;
        if (rottaroundtrackstart <= 0)
        {
          rotate = true;
        }

        if (rotate)
        {
            foreach (GameObject obj in objstoRot)
            {
                obj.transform.RotateAround(this.transform.position, this.transform.forward, rotationspeed * Time.deltaTime);
                obj.transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * 3.5f);
            }


        }
        


    }
}

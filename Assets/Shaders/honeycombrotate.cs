using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeycombrotate : MonoBehaviour
{

    public GameObject[] objs;


    private float rotationspeed;

    public bool rotate = false;
    private float rottaroundtrackstart = 8.9f;



    void Start()
    {
        rotationspeed = Random.Range(16, 22);
    }

    void Update()
    {
        rottaroundtrackstart -= Time.deltaTime;
        if (rottaroundtrackstart <= 0)
        {
            rotate = true;
        }

        if (rotate)
        {
            foreach (GameObject obj in objs)
            {
                obj.transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * 3.5f);
            }


        }
    }
}
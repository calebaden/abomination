using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldrotation : MonoBehaviour {

    public static worldrotation Instance;


    public GameObject floorcont;
    public GameObject skycont;

    private float initialdroppoint = -500;
    private float floorypos;

    private bool canrotate = false;


    public Vector3 worldrot;


    private float spinspeed = 7f;

    public bool dropfloor = false;
    public bool startrotation = false;


	void Start ()
    {
        Instance = this;
        floorypos = floorcont.transform.position.y;
	}
	



	void Update ()
    {

      if (floorypos >= initialdroppoint  && dropfloor)
        {
            floorypos -= Time.deltaTime * 30;
            canrotate = false;
            floorcont.transform.position = new Vector3(transform.position.x, floorypos, transform.position.z);

        }

        if (floorypos <= initialdroppoint && startrotation)
        {
            canrotate = true;
            Rotate();
        }

       

       
		
	}

    void Rotate()
    {
        floorcont.transform.RotateAround(this.transform.position, worldrot,  spinspeed * Time.deltaTime);
        skycont.transform.RotateAround(this.transform.position, worldrot, spinspeed * Time.deltaTime);

    }


}

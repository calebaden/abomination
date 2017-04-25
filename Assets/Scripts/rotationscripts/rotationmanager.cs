using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationmanager : MonoBehaviour {


    private Quaternion _indrotation;

    private Quaternion _worldrotation;

    private float indchangetimer;
    private float indchangebuffer = 10;

    private float Wchangetimer;
    private float Wchangebuffer = 25;



    private float Dropprestart = 8.9f;
    private float rotstart = 17.8f;
    private float Indprestart = 4.4f;
    

    void Start ()
    {
        Changeindrot();

        Changeworldrot();

        indchangetimer = indchangebuffer;
        Wchangetimer = Wchangebuffer;

    }
	
	void Update ()
    {

        Dropprestart -= Time.deltaTime;
        rotstart -= Time.deltaTime;
        Indprestart -= Time.deltaTime;
      
        if (Dropprestart <= 0)
        {
            worldrotation.Instance.dropfloor = true;
        }
        if (rotstart <= 0)
        {
            worldrotation.Instance.startrotation = true;
        }

        if (Indprestart <= 0)
        {
            independantrotation.Instance.startrotation = true;
        }

       

        indchangetimer -= Time.deltaTime;
        Wchangetimer -= Time.deltaTime;


        if (indchangetimer <= 0)
        {
            Changeindrot();
            indchangetimer = indchangebuffer;
        }

        if (Wchangetimer <= 0)
        {
            Changeworldrot();
            Wchangetimer = Wchangebuffer;
        }
    }


    void Changeindrot()
    {
        _indrotation = Random.rotation;
     //   Debug.Log(_indrotation);
        independantrotation.Instance.indrot = _indrotation.eulerAngles;
    }


    void Changeworldrot()
    {
       
        _worldrotation = Random.rotation;
       // Debug.Log(_worldrotation);
        worldrotation.Instance.worldrot = _worldrotation.eulerAngles;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourmanager : MonoBehaviour {

    public Material skybox;

    private Color colorStart = new Color32(0,116,174,0);

    private Color colorEnd = new Color32(99, 0, 174, 0);

    private float skyboxtransitionspeed = 0.2f;

	void Start ()
    {
        skybox.SetColor("_Color1", colorStart);

    }
	
	void Update ()
    {
        //skybox.SetColor("_Color1", Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time, 1)));

        skybox.SetColor("_Color1",Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time * skyboxtransitionspeed, 1.0f)));

    }
}

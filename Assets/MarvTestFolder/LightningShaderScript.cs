using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningShaderScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Time in seconds it takes to flash.")]
    float flashSpeed = 1;
    [SerializeField]
    [Tooltip("Time to show (in seconds) AFTER flash is done.")]
    float timeToShow = 1;

    private float timer = 0;

    private float progress = 0;

    Material mat;

	// Use this for initialization
	void Start ()
    {
        mat = GetComponent<Renderer>().material;
        timeToShow += flashSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        progress = timer / flashSpeed;
        mat.SetFloat("_Progress", progress);

        if (progress >= 1.0f && timer >= timeToShow)
        {
            Destroy(this.gameObject);
        }
	}
}

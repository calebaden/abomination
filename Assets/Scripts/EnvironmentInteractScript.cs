﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractScript : MonoBehaviour
{
    [Header("Common Variables")]
    public string type;
    public bool isActive = true;

    [Header("ParkTree Variables")]
    public GameObject leaves;
    public ParticleSystem leafParticles;
    Animator leafAnimator;

    [Header("PalmTree Variables")]
    public GameObject coconut;
    Rigidbody coconutRB;

    [Header("SnowTree Variables")]
    public ParticleSystem snowParticles;

    [Header("Lamp Variables")]
    public GameObject lampBulb;
    public Light spotLight;
    public Material offMat;
    public Material emissMat;
    public float maxIntensity;
    public float lightFadeSpeed;

    [Header("Bouy Variables")]
    public Animator bouyAnimator;

    [Header("Tumbleweed Variable")]
    public Vector3 verticalVector;
    public float torqueAmount;
    public float maxMagnitude;
    public float interactCooldown;
    float interactTimer;

    // Use this for initialization
    void Start ()
    {
        if (type == "PalmTree")
        {
            coconutRB = coconut.GetComponent<Rigidbody>();
        }
        else if (type == "Bouy")
        {
            bouyAnimator = GetComponent<Animator>();
        }
        else if (type == "Tumbleweed")
        {
            GetComponent<Rigidbody>().AddTorque(transform.forward * torqueAmount, ForceMode.Impulse);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Fades the spot lights intensity based on the lamps current state
		if (type == "Lamp" && isActive && spotLight.intensity < maxIntensity)
        {
            spotLight.intensity += lightFadeSpeed * Time.deltaTime;
        }
        else if (type == "Lamp" && !isActive && spotLight.intensity > 0)
        {
            spotLight.intensity -= lightFadeSpeed * Time.deltaTime;
        }
        else if (type == "Tumbleweed")
        {
            if (interactTimer > 0)
            {
                interactTimer -= Time.deltaTime;
            }
            else
            {
                isActive = true;
                interactTimer = interactCooldown;
            }
        }
	}

    // Function that checks the objects type and calls the appropriate function
    public void InteractionEvent ()
    {
        if (type == "ParkTree")
        {
            parkTreeInteraction();
        }
        else if (type == "SnowTree")
        {
            snowTreeInteraction();
        }
        else if (type == "PalmTree")
        {
            palmTreeInteraction();
        }
        else if (type == "Lamp")
        {
            lampInteraction();
        }
        else if (type == "Bouy")
        {
            bouyInteraction();
        }
        else if (type == "Tumbleweed")
        {
            tumbleweedInteraction();
        }
    }

    // Function that activates the park tree's animation and particle effect
    void parkTreeInteraction ()
    {
        if (isActive)
        {
            leafAnimator = leaves.GetComponent<Animator>();
            leaves.SetActive(true);
            leafAnimator.Play("Fall");
            leafParticles.Play();
            isActive = false;
        }
    }

    // Function that releases the snow from the snow tree
    void snowTreeInteraction ()
    {
        if (isActive)
        {
            snowParticles.Play();
            isActive = false;
        }
    }

    // Activates the bouy animation
    void bouyInteraction()
    {
        if (isActive)
        {
            bouyAnimator.Play("bouyBobbing");
            isActive = false;
        }
    }

    // Function that sets the kinematic value of the coconut object to false
    void palmTreeInteraction ()
    {
        if (isActive)
        {
            coconutRB.isKinematic = false;
            isActive = false;
        }
    }

    // Function changes the lamps state from on and off
    void lampInteraction ()
    {
        if (isActive)
        {
            lampBulb.GetComponent<Renderer>().material = offMat;
            isActive = false;
        }
        else
        {
            lampBulb.GetComponent<Renderer>().material = emissMat;
            isActive = true;
        }
    }

    // Function applies force to the tumbleweed object
    void tumbleweedInteraction ()
    {
        if (isActive)
        {
            Vector3 forceVector = transform.position - Camera.main.transform.position;
            forceVector = Vector3.ClampMagnitude(forceVector, maxMagnitude);
            GetComponent<Rigidbody>().AddForce(forceVector + verticalVector, ForceMode.Impulse);
            isActive = false;
        }
    }
}

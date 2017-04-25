using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{

    public float hitdis;
    private Light light;
    public List<Light> lights;

    // Use this for initialization
    void Start()
    {
        List<Light> lights = new List<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, hitdis))
        {
            if (hit.transform.gameObject.tag == "Collectible")
            {
                light = hit.transform.GetComponentInChildren<Light>();
                if (lights.IndexOf(light) < 0)
                {
                   lights.Add(light);
                }
                light.intensity = 8;
                if (Input.GetAxis("Fire1") > 0.1)
                {
                    Debug.Log("Hit");
                    hit.transform.GetComponentInChildren<ParticleSystem>().Play();
                    hit.transform.GetComponent<Collectible>().isTurning = true;
                    lights.Remove(light);
                    //if(hit.transform.gameObject.GetComponent<MeshRenderer>().enabled)
                        //hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            } else
            {
                ResetLight();
            }
        } else
        {
            ResetLight();
        }
    }

    void ResetLight()
    {
        if (lights.Count > 0)
        {
            foreach (Light light in lights)
            {
                light.intensity = light.intensity - 14 * Time.deltaTime;
            }
        }
    } 
        }

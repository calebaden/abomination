﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
    AudioSource source;

    //AudioManager audioManager;

    float[] spectrum = new float[64];
    Material matCar;
    public GameObject car;
    public float carZScale;
    public float multiplierPulseCar;


    //public GameObject[] leaves;
    public List<GameObject> leaves;
    public List<Material> leavesMat;
    public GameObject[] rocks;
    public List<Material> rocksMat;
    public List<Material> materialsToChange;
    //Differnt colors to move through
    public float timeToChangeColor;
    public float colorTime;
    public Colors[] songsColors;
    public int currentColor = 0;
    public float smoothValue;
    public Color lerpedColor = Color.white;

    public int currentSong;



    public bool pulse = false;
    public bool fade;
    public float fadeSpeed;
    public float t;


    public bool timerNoMusic;
    public float timerForPulse;
    float tp;

    AudioManager audioManager;

    public int index = 0;

    [System.Serializable]
    public struct Colors
    {
       
        public Color[] colors;
    }


    //public Collider treeDistCollider;


    // Use this for initialization
    void Start()
    {


        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        //source.clip = audioManager.randomizedSong;

        source = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        matCar = car.GetComponent<Renderer>().material;
        carZScale = car.transform.lossyScale.z;

        //UpdateMatArray();

        rocks = GameObject.FindGameObjectsWithTag("Rocks");
        //leaves = GameObject.FindGameObjectsWithTag("Trees");

        timerForPulse = audioManager.currentBPM;


    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject tree in GameObject.FindGameObjectsWithTag("Trees") )
        {
            if( !tree.GetComponent<Rigidbody>() )
            {
                tree.AddComponent<Rigidbody>();
                tree.GetComponent<Rigidbody>().isKinematic = true;
                tree.GetComponent<Rigidbody>().useGravity = false;
            }

        }


        foreach (GameObject rock in GameObject.FindGameObjectsWithTag("Rocks"))
        {
            if (!rock.GetComponent<Rigidbody>())
            {
                rock.AddComponent<Rigidbody>();
                rock.GetComponent<Rigidbody>().isKinematic = true;
                rock.GetComponent<Rigidbody>().useGravity = false;
            }

        }


        source.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);




        //Vector3 pos = transform.position;
        //pos.y = pos.y*0.9f + spectrum[0]*0.1f;
        //transform.position = pos;



        //Changing color
        colorTime += Time.deltaTime;
        if (colorTime > timeToChangeColor)
        {
            
            if (currentColor >= songsColors[currentSong].colors.Length - 1)
            {
                currentColor = 0;
                
            }
            else
            {
               
                ++currentColor;
            }
            fade = true;
            t = 0;
           


            colorTime = 0;
        }
        if (fade)
        {
            if (currentColor - 1 >= 0)
            {

                lerpedColor = Color.Lerp(songsColors[currentSong].colors[currentColor - 1], songsColors[currentSong].colors[currentColor], t);

            }
            else
            {
                lerpedColor = Color.Lerp(songsColors[currentSong].colors[songsColors[currentSong].colors.Length-1], songsColors[currentSong].colors[currentColor], t);
            }

           

            foreach (Material m in materialsToChange)
            {

                Debug.Log(currentColor);
                m.SetColor("_Color", lerpedColor);



            }
            t += fadeSpeed * Time.deltaTime;
            if (t >= 1)
            {
                t = 0;
                fade = false;
            }

        }

        if (!timerNoMusic)
        {


            if (spectrum[0] > 0.12f && !pulse)
            {
                pulse = true;
                smoothValue = 0;
            }
            if (pulse)
            {
                smoothValue += Time.deltaTime * multiplierPulseCar;
                if (smoothValue > carZScale)
                {
                    pulse = false;
                    smoothValue = 0;
                }
            }
        }
        else
        {

            tp += Time.deltaTime;
            if (tp >= timerForPulse)
            {
                smoothValue += Time.deltaTime * multiplierPulseCar;
                if (smoothValue > carZScale)
                {
                    pulse = false;
                    smoothValue = 0;
                }
            }


        }
        //For car
        matCar.SetFloat("_Music", smoothValue);

        foreach (Material m in materialsToChange )
        {
            m.SetFloat("_Music", smoothValue);
        }

        //    //For trees
        //    foreach (Material m in leavesMat)
        //{
        //    m.SetFloat("_Music", smoothValue);
        //    Debug.Log("tress");
        //}
        ////For rocks
        //foreach (Material m in rocksMat)
        //{
        //    m.SetFloat("_Music", smoothValue);
        //    Debug.Log("rocks");
          
        //}






        //smoothValue = smoothValue * 0.9f + spectrum[0] * 0.1f;
        //mat.SetFloat("_Music", Mathf.Sin (smoothValue));


        for (int i = 1; i < 64; ++i)
        {
            Debug.DrawLine(new Vector3((i - 1) / 100f, spectrum[i - 1], 0), new Vector3(i / 100, spectrum[i], 0), Color.red);
        }
    }

    //public void UpdateMatArray() {



    //    for (int i = 0; i < leaves.Length; ++i)
    //    {



    //        if (leaves[i].GetComponent<Renderer>() != null) {

    //            Material[] tempMats = leaves[i].GetComponent<Renderer>().materials;

    //            foreach (Material m in tempMats)
    //            {
    //                if (m.shader.name == "Custom/tree")
    //                {
    //                    leavesMat.Add(m);
    //                    materialsToChange.Add(m);

    //                }
    //            } 
    //        }
    //    }

    //    for (int i = 0; i < rocks.Length; ++i)
    //    {



    //        if (rocks[i].GetComponent<Renderer>() != null) {

    //            Material[] tempMats = rocks[i].GetComponent<Renderer>().materials;

    //            foreach (Material m in tempMats)
    //            {
    //                if (m.shader.name == "Custom/rock")
    //                {
    //                    rocksMat.Add(m);
    //                    materialsToChange.Add(m);

    //                }
    //            }
    //        }
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trees"))
        {
            Material[] tempMats = other.GetComponent<Renderer>().materials;

            foreach (Material m in tempMats)
            {
                if (m.shader.name == "Custom/tree")
                {
                    materialsToChange.Add(m);

                }
            }
        }

        if (other.CompareTag("Rocks"))
        {
            Material[] tempMats = other.GetComponent<Renderer>().materials;

            foreach (Material m in tempMats)
            {
                if (m.shader.name == "Custom/tree")
                {
                    materialsToChange.Add(m);

                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trees"))
        {
            Material[] tempMats = other.GetComponent<Renderer>().materials;

            foreach (Material m in tempMats)
            {
                if (m.shader.name == "Custom/tree")
                {
                    materialsToChange.Remove(m);

                }
            }
        }

        if (other.CompareTag("Rocks"))
        {
            Material[] tempMats = other.GetComponent<Renderer>().materials;

            foreach (Material m in tempMats)
            {
                if (m.shader.name == "Custom/tree")
                {
                    materialsToChange.Remove(m);

                }
            }
        }
    }
}
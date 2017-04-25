using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadbordercontroller : MonoBehaviour {

    private GameObject player;
    private float Ytop;
    private float Ybot;

    private bool startsearching = false;

    private void Start()
    {

       
        Ytop = transform.position.y;
        Ybot = Ytop - 30;
        Debug.Log(Ytop);
        Debug.Log(Ybot);
    }
    
    
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        float PDist = Vector3.Distance(this.transform.position, player.transform.position);
            if (PDist <= 65)
            {

                if (transform.localScale != new Vector3(8, 2, 20))
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(8, 2, 20), 3 * Time.deltaTime);
                }

                if (transform.position.y < Ytop)

                    transform.Translate(Vector3.up * 0.6f);
            }

            else
            {
                transform.localScale = new Vector3(0, 0, 0);

                if (transform.position.y > Ybot)
                    transform.Translate(-Vector3.up * 1);
            }
        }

       
    }

    








    


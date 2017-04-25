using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class timer : MonoBehaviour {
	public Text timerLabel;
	public float startTimer = 0;
	private float time;

	void Update()
    {
        Timer();
	}

    public void Timer()
    {
        time += Time.deltaTime;

        float minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        float seconds = time % 60;//Use the euclidean division for the seconds.
        float fraction = (time * 100) % 100;


        //update the label value
       // timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathRestart")
        {
            Debug.Log("Reset");
            time = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            time = 0;
        }
    }
}





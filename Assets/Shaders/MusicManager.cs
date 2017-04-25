using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {

    [Tooltip("The audiosource playing the music.")]
    public AudioSource audioSource;
    float[] spectrum = new float[64];
    [Tooltip("How heavy the bass should be to count as a beat.")]
    public float beatThreshhold = 0.5f;

    [Tooltip("Minimum wait time between beats.")]
    public float beatCooldown = 0.2f;
    bool hasBeat = false;
    float cooldownTimer= 0;

    [Tooltip("All objects that need to respond to the beat.")]
    public List<GameObject> receivers = new List<GameObject>();
    List<BeatReceiver> recs = new List<BeatReceiver>();

    List<float> recentBeats = new List<float>();
    int avgLimit = 8;
    float avgIntensity = 0;

	void Start ()
    {
        if (receivers.Count > 0)
        {
            for (int i = 0; i < receivers.Count; i++)
            {
                recs.Add(receivers[i].GetComponent<BeatReceiver>());
            }
        }
	}

    void Update()
    {
        if (hasBeat)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                hasBeat = false;
            }
        }

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);

        if(spectrum[0] > 0.5f && !hasBeat)
        {
            if (spectrum[0] > beatThreshhold)
            {
                SendBeat();
            }

            recentBeats.Add(spectrum[0]);
            if(recentBeats.Count > avgLimit)
            {
                recentBeats.RemoveAt(0);
            }

            float avgIntensity = CalcAvgIntensity();

            print(avgIntensity);

            if (avgIntensity > 0.8f && recentBeats.Count == avgLimit)
            {
                beatThreshhold = 0.8f;
            }
            else if (avgIntensity < 0.65f)
            {
                beatThreshhold = 0.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SendBeat();   
        }
	}

    void SendBeat()
    {
        hasBeat = true;
        cooldownTimer = beatCooldown;

        for (int i = 0; i < recs.Count; i++)
        {
            recs[i].OnBeat();
        }
    }

    float CalcAvgIntensity()
    {
        float output = 0;

        for (int i = 0; i < recentBeats.Count; i++)
        {
            output += recentBeats[i];
        }

        output /= recentBeats.Count;

        return output;
    }
}

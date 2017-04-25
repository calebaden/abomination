using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //array of floats necessary for scenery changes.
    public float[] songTimes;
    public AudioClip[] songFiles;
    public float[] songBPMTimer;
    public int[] timeOfDay;

    //Song string array
    
    string[] songNames = new string[] { "Feel It", "Blue Between" };
    //Text Change
    public Text songNameText;

    public float timeRemaining;

    public AudioSource audioSource;

    public AudioClip randomizedSong;

    public int currentSong;
    public int[] songPlayOrder;

    public int currentTime;

    public float currentBPM;

    skyTimeChanger SkyTimeChanger;

    // Use this for initialization
    void Start()
    {
        SkyTimeChanger = GameObject.FindGameObjectWithTag("sky").GetComponent<skyTimeChanger>();

        
        for (int i = 0; i < songFiles.Length; i++)
        {
            songTimes[i] = songFiles[i].length;
        }

        
        loopPlay();
        if (currentSong >= songFiles.Length)
        {
            loopPlay();
            currentSong = 0;
        }

        randomizedSong = (songFiles[songPlayOrder[currentSong]]);
        currentTime = timeOfDay[songPlayOrder[currentSong]];
        currentBPM = songBPMTimer[songPlayOrder[currentSong]];
        songNameText.text = randomizedSong.name;
        audioSource.PlayOneShot(randomizedSong);
        timeRemaining = randomizedSong.length;
        SkyTimeChanger.progressStage(timeOfDay[songPlayOrder[currentSong]]);
        SkyTimeChanger.lerpSpeedMidStage = songTimes[songPlayOrder[currentSong]];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        //timeRemaining = randomizedSong.length;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0.0f) {
            NewSong();
            
        }
        print(songPlayOrder[currentSong]);
    }

    //randomize new song at end of song.
    public void NewSong() {
        currentSong++;
        audioSource.Stop();
        if (currentSong >= songFiles.Length)
        {
            loopPlay();
            currentSong = 0;
        }
            
        randomizedSong = (songFiles[songPlayOrder[currentSong]]);
        currentTime = timeOfDay[songPlayOrder[currentSong]];
        currentBPM = songBPMTimer[songPlayOrder[currentSong]];
        songNameText.text = randomizedSong.name;
        audioSource.PlayOneShot(randomizedSong);
        timeRemaining = randomizedSong.length;
        SkyTimeChanger.progressStage(timeOfDay[songPlayOrder[currentSong]]);
        SkyTimeChanger.lerpSpeedMidStage = songTimes[songPlayOrder[currentSong]];
    }
    public void loopPlay()
    {
        for (int i = 0; i < songFiles.Length; i++)
        {
            songPlayOrder[i] = 70000;
        }
        for (int i = 0; i < songFiles.Length; i++)
        {
            songPlayOrder[i] = 70000;
            int nextNum;
            bool There;
            do
            {
                nextNum = Random.Range(0, songFiles.Length);
                There = false;
                for (int ii = 0; ii < songFiles.Length; ii++)
                {
                    if(nextNum == songPlayOrder[ii])
                    {
                        
                        There = true;
                    }
                }
                print(nextNum);
            }
            while (There);
            songPlayOrder[i] = nextNum;

        }
    }


}

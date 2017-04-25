using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbominationManager : MonoBehaviour
{
    public static AbominationManager Instance;

    public Image fadeImg;
    public Text loadTxt;
    public float levelTime = 300;
    public float timeLimit;
    public float fadeSpeed;
    Color imgColor;
    int currentScene;
    bool isFading = false;

	// Use this for initialization
	void Start ()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        loadTxt.enabled = false;
        imgColor = fadeImg.color;
        timeLimit = levelTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // FOR DEV DEBUG USE
		if (Input.GetKeyDown("n"))
        {
            StartCoroutine(FadeImage());
        }

        Fading();

        if (currentScene == 0 || currentScene == 1)
        {
            if (timeLimit > 0)
            {
                timeLimit -= Time.deltaTime;
            }
            else
            {
                CallCoroutine();
            }
        }
    }

    void Fading ()
    {
        if (isFading && fadeImg.color.a < 1)
        {
            imgColor.a += fadeSpeed * Time.deltaTime;
            fadeImg.color = imgColor;
        }
        else if (!isFading && fadeImg.color.a > 0)
        {
            imgColor.a -= fadeSpeed * Time.deltaTime;
            fadeImg.color = imgColor;
        }
    }

    // CALL THIS AT THE END OF THE PROJECT
    public void CallCoroutine()
    {
        StartCoroutine(FadeImage());
    }
    // ^^^^^^^^^

    IEnumerator FadeImage ()
    {
        isFading = true;

        yield return new WaitUntil(() => fadeImg.color.a >= 1);

        ChangeScene();
        yield break;
    }

    // Loads the next scene in the project
    void ChangeScene()
    {
        Camera.main.GetComponent<AudioListener>().enabled = false;
        isFading = true;
        loadTxt.enabled = true;

        if (currentScene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            currentScene++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            currentScene = 1;
            SceneManager.LoadScene(0);
        }
    }

    void OnLevelWasLoaded ()
    {
        isFading = false;
        loadTxt.enabled = false;
        timeLimit = levelTime;
    }
}

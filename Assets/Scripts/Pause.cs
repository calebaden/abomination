using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    // VARIABLES AND CONSTANTS.
    public GameObject pauseButton, pausePanel;
    public AudioSource music;

    // Use this for initialization
    public void Start () {

        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        music.Play();
        Time.timeScale = 1;
    }

    public void OnPause() {

        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        music.Pause();
        Time.timeScale = 0;
    }

    public void OnClick() {

        Application.OpenURL("https://soundcloud.com/stormboydeadz");
    }

    public void OnRestartClick() {

        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}

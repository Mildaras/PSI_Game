using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject score;
    public PlayerMovement playerMovement;
    //public AudioSource music; // Reference to the music AudioSource
    private bool isPaused = true;
    public Text startText;
    public GameObject pressAnyText;
    public PlayerData pData;

    void Start()
    {
        startText.text = "";
        pausePanel.SetActive(true); // Set the pause panel to be inactive by default
        StopGame();
    }

    void Update()
    {
        if (Input.anyKeyDown && isPaused)
        {
            StartCoroutine(Waiting());
        }
    }

    void StopGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        playerMovement.enabled = false;
        AudioListener.pause = true; // Pause all audio in the scene
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        score.SetActive(true);
        playerMovement.enabled = true;
        AudioListener.pause = false;
        isPaused = false;
    }

    IEnumerator Waiting()
    {
        pData.ResetSc();
        pressAnyText.SetActive(false);
        startText.text = "3";
        yield return new WaitForSecondsRealtime(1);
        startText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        startText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        startText.text = "";
        StartGame();
        isPaused = false;
    }
}

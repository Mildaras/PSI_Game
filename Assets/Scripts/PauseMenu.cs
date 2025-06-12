using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Slider;
    public GameObject Slider2;
    public GameObject MenuText;
    public GameObject ButtonBack;
    public GameObject PausedBack;
    public GameObject ScoreGUI;
    public GameObject VadimGUI;
    public GameObject Score;
    public GameObject Health;
    public PlayerMovement playerMovement;
    //public AudioSource music; // Reference to the music AudioSource
    private bool isPaused = false;
    public Text startText;

    void Start()
    {
        pausePanel.SetActive(false); // Set the pause panel to be inactive by default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            StartCoroutine(Waiting());
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        MenuText.SetActive(true);
        PausedBack.SetActive(true);
        ButtonBack.SetActive(true);
        ScoreGUI.SetActive(false);
        VadimGUI.SetActive(false);
        Health.SetActive(false);
        Score.SetActive(false);
        playerMovement.enabled = false;
        AudioListener.pause = true; // Pause all audio in the scene
    }

    public void ResumeButton()
    {
        StartCoroutine(Waiting());
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        playerMovement.enabled = true;
        AudioListener.pause = false;
        isPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        playerMovement.enabled = true;
        AudioListener.pause = false;
        SceneManager.LoadScene("TitleScene");
    }

    public void Settings()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(true);
        Slider.SetActive(true);
        Slider2.SetActive(true);
    }

    public void Back()
    {
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(false);
        Slider.SetActive(false);
        Slider2.SetActive(false);
    }

    IEnumerator Waiting()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        Slider.SetActive(false);
        Slider2.SetActive(false);
        MenuText.SetActive(false);
        PausedBack.SetActive(false);
        ButtonBack.SetActive(false);
        startText.text = "3";
        yield return new WaitForSecondsRealtime(1);
        startText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        startText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        startText.text = "";
        ScoreGUI.SetActive(true);
        VadimGUI.SetActive(true);
        Health.SetActive(true);
        Score.SetActive(true);
        ResumeGame();
        isPaused = false;
    }
}

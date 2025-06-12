using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuBoss : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Slider;
    public GameObject MenuText;
    public GameObject PausedBack;
    public GameObject ButtonBack;
    //public AudioSource music; // Reference to the music AudioSource
    private bool isPaused = false;
    public Text startText;
    public PlayerMoves playerMoves;
    public VaciusMoves vaciusMoves;

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
        playerMoves.enabled = false;
        vaciusMoves.enabled = false;
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
        AudioListener.pause = false;
        playerMoves.enabled = true;
        vaciusMoves.enabled = true;
        isPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        AudioListener.pause = false;
        playerMoves.enabled = true;
        vaciusMoves.enabled = true;
        SceneManager.LoadScene("TitleScene");
    }

    public void Settings()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(true);
        Slider.SetActive(true);
    }

    public void Back()
    {
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(false);
        Slider.SetActive(false);
    }

    IEnumerator Waiting()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        Slider.SetActive(false);
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
        ResumeGame();
        isPaused = false;
    }
}

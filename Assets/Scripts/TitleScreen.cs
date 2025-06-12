using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void CutScene()
    {
        SceneManager.LoadScene("CutSceneStart");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

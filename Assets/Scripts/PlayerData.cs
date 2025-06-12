using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static int PlayerScore;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HealthText;
    public Conductor conductor;
    public ObstacleCollision obstacleCollision;

    private void Awake()
    {
        //ScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ScoreText.text = ""+PlayerScore;
        HealthText.text = ""+obstacleCollision.lives;
    }

    public void AddScore(int newScore)
    {
        PlayerScore += newScore;
    }

    public void Score3x()
    {
        PlayerScore *= 3;
    }

    public void Heart()
    {
        if(obstacleCollision.lives < 3)
        {
            obstacleCollision.lives++;
        }
        else
        {
            AddScore(1000);
        }
    }

    public void ResetSc()
    {
        PlayerScore = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossGameEnd : MonoBehaviour
{
    public GameObject lastNote;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject bossObject;
    public GameObject bossEye1;
    public GameObject bossEye2;
    public Sprite bossSprite;
    public SpriteRenderer bosser;
    public Slider slider;
    public Shake bossShake;
    public BossManager boss;
    public Text winText;
    public bool won = false;
    public AudioSource music;
    public ParticleSystem explosion;
    public PlayerMoves pmoves;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = slider.maxValue - boss.newScore;
        float tttime = music.time;
        if(boss.newScore > slider.maxValue && tttime > 58 )
        {
            tttime = 59;
            pmoves.enabled = false;
            StartCoroutine(BossDeath());
            /*winScreen.SetActive(true);
            won = true;
            SceneManager.LoadScene("CutSceneEnd");*/
        }
        if(boss.newScore > slider.maxValue)
        {
            bosser.sprite = bossSprite;
            bossEye1.SetActive(false);
            bossEye2.SetActive(false);
        }
        if (boss.newScore < slider.maxValue && tttime > 58)
        {
            tttime = 59;
            loseScreen.SetActive(true);
            won = true;
            //StartCoroutine(BossDeath());
            //StartCoroutine(WinGame());
            //loseScreen.SetActive(true);
            //won = true;
        }

    }

    IEnumerator BossDeath()
    {
        bossShake.start = true;
        yield return new WaitForSecondsRealtime(5);
        explosion.Play();
        Destroy(bossObject, 0);
        yield return new WaitForSecondsRealtime(2);
        won = true;
        SceneManager.LoadScene("CutSceneEnd");
    }

    IEnumerator WinGame()
    {
        loseScreen.SetActive(true);
        won = true;
        yield return null;
    }
}

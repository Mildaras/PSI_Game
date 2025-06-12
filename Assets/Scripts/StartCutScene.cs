using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StartCutScene : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
    public GameObject text12;
    public GameObject textBlock2;
    public GameObject textBlock;
    public AudioSource IntroMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!text1.active)
        {
            StartCoroutine(Waiting(text1, 4f));
        }
        if (text1.active)
        {
            StartCoroutine(Waiting(text2, 3.5f));
        }
        if (text2.active)
        {
            StartCoroutine(Waiting(text3, 3.5f));
        }
        if (text3.active)
        {
            StartCoroutine(Waiting(text4, 3.5f));
        }
        if (text4.active)
        {
            StartCoroutine(Waiting(text5, 3.5f));
        }
        if (text5.active)
        {
            StartCoroutine(Waiting(text6, 3.5f));
        }
        if (text6.active)
        {
            StartCoroutine(Waiting(text7, 3.5f));
        }
        if (text7.active)
        {

            StartCoroutine(WaitingBlock(textBlock, 3.5f));
            StartCoroutine(Waiting(text8, 3.5f));
        }
        if (text8.active)
        {
            StartCoroutine(WaitingBlock(textBlock2, 3.5f));
            StartCoroutine(Waiting(text9, 3.5f));
        }
        if (text9.active)
        {
            StartCoroutine(Waiting(text10, 3.5f));
        }
        if (text10.active)
        {
            StartCoroutine(Waiting(text11, 3.5f));
        }
        if (text11.active)
        {
            StartCoroutine(Waiting(text12, 3.5f));

        }
        if (text12.active)
        {
            StartCoroutine(WaitingScene(3f));
        }

    }

    IEnumerator Waiting(GameObject bruh, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        bruh.SetActive(true);
    }

    IEnumerator WaitingBlock(GameObject block, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        block.SetActive(false);
    }
    IEnumerator WaitingScene(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("Game");
    }
}

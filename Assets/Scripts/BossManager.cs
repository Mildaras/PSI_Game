using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static BossManager instance;
    public Shake shake;
    public GameObject speedLines;
    public BossHitFlash bosshitflash;
    public Rigidbody playa;

    public int currentScore;
    public int newScore;
    public int scorePerNote = 100;

    public int scorePerGoodNote = 100;
    public int scorePerPerfectNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScore = VariableSave.PlayerScore;
        scoreText.text = "" + currentScore.ToString();
        currentMultiplier= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(theMusic.time > 30.8f)
        {
            speedLines.SetActive(false);
        }
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying=true;
                theBS.hasStarted=true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
        shake.start = true;
        bosshitflash.hit = true;
        playa.velocity = new Vector3(0, 4f, 0);
        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
        multiplierTracker++;

        if(multiplierThresholds[currentMultiplier - 1] <=multiplierTracker)
        {
            multiplierTracker=0;
            currentMultiplier++;
        }
        }

        multiText.text= "x" + currentMultiplier;

        //currentScore+=scorePerNote * currentMultiplier;
        scoreText.text = "" + currentScore;
        VariableSave.PlayerScore = currentScore;
    }
    
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        newScore += scorePerNote * currentMultiplier;
        NoteHit();
    }
    
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        newScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        newScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier=1;
        multiplierTracker=0;

        multiText.text= "x" + currentMultiplier;
    }
}

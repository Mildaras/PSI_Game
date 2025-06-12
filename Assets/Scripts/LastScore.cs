using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastScore : MonoBehaviour
{
    public TextMeshProUGUI finalscore;
    // Start is called before the first frame update
    void Start()
    {
        finalscore.text = "Score: " + VariableSave.PlayerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaciusMoves : MonoBehaviour
{
    private bool hasStarted = false;
    private bool movingRight = true;
    public BossGameEnd bossGameEnd;
    void Start()
    {
        
    }

    void Update()
    {
       
       if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            if(bossGameEnd.won)
            {
                transform.Rotate(90.0f, 0.0f, 0.0f);
                enabled = false;
            }
            else
            {
                if (movingRight)
                {
                    transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                    if (transform.position.x >= -1.6f)
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                    if (transform.position.x <= -3.6f)
                    {
                        movingRight = true;
                    }
                }
            }
        }
    
    }
}


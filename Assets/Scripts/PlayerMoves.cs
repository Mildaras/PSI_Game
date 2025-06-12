using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
private bool hasStarted = false;
    private bool movingRight = true;
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
            if (movingRight)
            {
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                if (transform.position.x <= -6.8f)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                if (transform.position.x >= -6f)
                {
                    movingRight = true;
                }
            }
        }
    
    }
}


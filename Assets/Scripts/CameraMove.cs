using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());
        if(k == 1)
        {
            var step = 5f * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(-5f, 1.5f, -403.600006f), step);
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSecondsRealtime(2);
        k = 1;
    }
}

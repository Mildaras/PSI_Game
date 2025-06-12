using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject speedLines;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(keyToPress))
       {
        if(canBePressed)
        {
            if(gameObject.tag == "RushStart")
            {
                    speedLines.SetActive(true);
            }

            gameObject.SetActive(false);

            //BossManager.instance.NoteHit();
            //hit
            if(transform.position.y > 0.1 && transform.position.y < 0.25)
            {
                BossManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            //hit
            else if(transform.position.y > 0.61 && transform.position.y < 0.76)
            {
                BossManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            //good
            else if(transform.position.y > 0.25 && transform.position.y < 0.34){
                BossManager.instance.GoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            //good
            else if(transform.position.y > 0.52 && transform.position.y < 0.61)
            {
                BossManager.instance.GoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            else
            {
                BossManager.instance.PerfectHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
        }
       } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;

            BossManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}

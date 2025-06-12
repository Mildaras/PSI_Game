using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitFlash : MonoBehaviour
{
    public SpriteRenderer BossSprite;
    public Sprite BossNormal;
    public Sprite BossHit;

    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hit == true)
        {
            hit = false;
            StartCoroutine(BossHite());
        }
    }

    IEnumerator BossHite()
    {
        Sprite gg = BossSprite.sprite; 
        BossSprite.sprite = BossHit;
        yield return new WaitForSecondsRealtime(0.1f);
        if(gg == BossNormal)
        BossSprite.sprite = BossNormal;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    private int health = 10;
    private bool CanDamage=true;
    public AudioSource Audio;
    private void Awake()
    {
        anim = GetComponent<Animator>(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            if (CanDamage)
            {
                StartCoroutine(WaitForDamage());
                health--;
                CanDamage = false;
                if (health == 0)
                {
                    Audio.Play();
                    anim.Play("BossDead");
                    GetComponent<Boss_Scripts>().DeActivateAfterDelay(2f);
                    
                }
            }
        }
    }
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        CanDamage = true;
    }

}//class

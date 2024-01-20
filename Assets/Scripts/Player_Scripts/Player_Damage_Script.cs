using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Damage_Script : MonoBehaviour
{
    public TextMeshProUGUI LifeText;
    public Behaviour MovementScript;
    public Behaviour PlayerShoot;
    public Animator anim;
    private int Lifescore;
    private bool CanDamage;
    public AudioSource DamageAudio;
    private void Awake()
    {
        Lifescore = 3;
        //anim = GetComponent<Animator>();
        CanDamage =true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        if (CanDamage)
        {
            Lifescore--;
            
            if (Lifescore >= 0)
            {
                LifeText.text = "X " + Lifescore;
            }
            if (Lifescore == 0)
            {
                // we can stop time and load scene with help of 
                //WaitForSecondsRealtime(3f)
                //and can do Time.timeScale=0f it will work 
                //as real time is indepandent of scene
                DamageAudio.Play();
                MovementScript.enabled = false;
                PlayerShoot.enabled=false;
                anim.Play("PlayerDead");
                StartCoroutine(RestartLevel());
                //Time.timeScale = 0f;
                
            }
            CanDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        CanDamage = true;
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("FirstLevel");
    }


}//class

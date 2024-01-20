using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_Scripts : MonoBehaviour
{
    private Animator anim;
    private bool Animation_Started;
    private bool Animation_Finished;
    private int Jumpedcount;
    private Rigidbody2D mybody;
    private bool jumpleft = true;
    private string coroutine_name = "FrogJump";
    public LayerMask Player_layer;
    public GameObject Player;
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutine_name);
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, Player_layer))
        {
            Player.GetComponent<Player_Damage_Script>().DealDamage();
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(Animation_Finished && Animation_Started)
        {
            Animation_Started = false;
            transform.parent.position = transform.position;
            transform.localPosition=Vector3.zero;
        }
        
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(2f);
        Animation_Started=true;
        Animation_Finished = false;
        Jumpedcount++;
        if (jumpleft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }
        StartCoroutine(coroutine_name);
    }

    void AnimationFinish()
    {
        Animation_Finished=true;
        //print("Event Called");
        if (jumpleft)
        {
            anim.Play("frog_ideal_left");
        }
        else
        {
            anim.Play("frog_ideal_right");
        }
        if(Jumpedcount==3)
        {
            Jumpedcount = 0;
            Vector3 tempScale= transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
            jumpleft = !jumpleft;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            anim.Play("FrogDead");
            StartCoroutine(FrogDead());
        }
    }

    IEnumerator FrogDead()
    {
        yield return new WaitForSeconds(0.5f);
        mybody.velocity = Vector2.zero;
        transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}//class

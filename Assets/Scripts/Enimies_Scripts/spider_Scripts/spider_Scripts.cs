using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_Scripts : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D mybody;
    private Vector3 moveDirection=Vector3.down;
    private string Coroutine_Name = "ChangeDirection";
    void Awake()
    {
        anim=GetComponent<Animator>();
        mybody=GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate(moveDirection*Time.smoothDeltaTime);

    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(3);
        if(moveDirection==Vector3.down)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.down;
        }
        StartCoroutine(Coroutine_Name);
    }
    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            anim.Play("spider_dead");
            mybody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            StopCoroutine(Coroutine_Name);

        }   
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Damage_Script>().DealDamage();
        }
    }




}//class
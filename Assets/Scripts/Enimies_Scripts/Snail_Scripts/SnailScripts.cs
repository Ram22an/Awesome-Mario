using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float Move_speed=1f;
    private Rigidbody2D mybody;
    private Animator anim;
    private bool moveleft;
    private bool CanMove;
    private bool Stunned;
    public Transform left_Collision, right_Collision, top_Collision, down_Collision;
    private Vector3 left_Collision_position, right_Collision_position;
    public LayerMask Player_layer;
    //GameObject down_Collision1 = GameObject.Find("down_Collision");
    //GameObject down_Collision1 = GameObject.FindWithTag("down_Collision_Tag");
    //Transform down_Collision= down_Collision1.GetComponent<Transform>();
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveleft = true;
        CanMove = true;
        left_Collision_position=left_Collision.position;
        right_Collision_position = right_Collision.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left_Collision_position = left_Collision.position;
        right_Collision_position = right_Collision.position;
        if (CanMove)
        {
            if (moveleft)
            {
                mybody.velocity = new Vector2(-Move_speed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(Move_speed, mybody.velocity.y);
            }
        }
        CheckCollision();
        
    }
    
    void CheckCollision()
    {
        RaycastHit2D left_hit=Physics2D.Raycast(left_Collision.position,Vector2.left,0.1f,Player_layer);
        RaycastHit2D right_hit=Physics2D.Raycast(right_Collision.position, Vector2.right,0.1f,Player_layer);
        Collider2D top_hit = Physics2D.OverlapCircle(top_Collision.position, 0.2f, Player_layer);
        if (top_hit!=null) {
            if (top_hit.gameObject.tag == "Player")
            {
                if (!Stunned)
                {
                    top_hit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(top_hit.gameObject.GetComponent<Rigidbody2D>().velocity.x,7f);
                    CanMove = false;
                    mybody.velocity = new Vector2(0, 0);
                    anim.Play("stunned");
                    Stunned = true;
                    if (tag == "beetle")
                    {
                        anim.Play("stunned");
                        StartCoroutine(Dead(0.5f));
                    }
                }
            }
        }
        if (left_hit)
        {
            if (left_hit.collider.gameObject.tag == "Player")
            {
                if (!Stunned)
                {
                    left_hit.collider.gameObject.GetComponent<Player_Damage_Script>().DealDamage();
                    print("Here you have hit the left collider");
                }
                else
                {
                    if (tag != "beetle")
                    {
                        mybody.velocity = new Vector2(15f, mybody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
        if (right_hit)
        {
            if (right_hit.collider.gameObject.tag == "Player")
            {
                if (!Stunned)
                {
                    right_hit.collider.gameObject.GetComponent<Player_Damage_Script>().DealDamage();
                    print("You have collided with right collider");
                }
                else
                {
                    if (tag != "beetle")
                    {
                        mybody.velocity = new Vector2(-15f, mybody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
        // IF we don't detect collision any more do whats in {}
        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f) ){
            
            Changedirection();
            //moveleft = !moveleft; 
        }
        //if(Physics2D.Raycast(gameObject.transform.position,Vector2.left,1f, Boundry) )
        //{
          //  Changedirection();
        //}
    }

    void Changedirection()
    {
        moveleft = !moveleft;
        Vector2 temp = transform.localScale;
        if(moveleft)
        {
            temp.x=Mathf.Abs(temp.x);
            left_Collision.position = left_Collision_position;
            right_Collision.position = right_Collision_position;
        }
        else
        {
            temp.x = -Mathf.Abs(temp.x);
            left_Collision.position = right_Collision_position;
            right_Collision.position = left_Collision_position;
        }
        transform.localScale = temp;
    }
    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boundry")
        {
            //print("It is happening");
            Changedirection();
        }
        if (collision.gameObject.tag == "bullet")
        {
            if (tag == "beetle")
            {
                anim.Play("stunned");
                CanMove = false;
                mybody.velocity = Vector2.zero;
                StartCoroutine(Dead(0.2f));
            }
            if (tag == "snail")
            {
                if(!Stunned)
                {
                    anim.Play("stunned");
                    Stunned = false;
                    CanMove = false;
                    mybody.velocity = Vector2.zero;
                }
                else
                {
                    gameObject.SetActive(false);
                }
                
            }
        }   
    }


}//Class

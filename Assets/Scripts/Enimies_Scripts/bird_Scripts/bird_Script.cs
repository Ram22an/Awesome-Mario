using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_Script : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    //vector3.left is equal to (-1,0,0)
    private Vector3 moveDirection=Vector3.left;
    private Vector3 originposition;
    private Vector3 moveposition;
    public GameObject birdegg;
    public LayerMask playerLayer;
    //private bool attacked=false; is same as below
    private bool attacked;
    private bool CanMove;
    private float speed = 2.5f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originposition= transform.position;
        originposition.x += 6f;
        moveposition = transform.position;
        moveposition.x -= 6f;
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBird();
        DropEgg();
    }
    void MoveBird()
    {
        if(CanMove)
        {
            transform.Translate(moveDirection*speed*Time.smoothDeltaTime);
            if(transform.position.x >= originposition.x)
            {
                //transform.localRotation =  Quaternion.Euler(0f, 0f, 0f); ;
                moveDirection = Vector3.left;
                ChangeDirection(0.5f);
            }
            else if(transform.position.x<=moveposition.x) 
            { 
                moveDirection= Vector3.right;
                ChangeDirection(-0.5f);
                //transform.localRotation = Quaternion.Euler(0f, 180f, 0f); ;
            }
        }
    }

    void ChangeDirection(float direction)
    {
        Vector3 temp = transform.localScale;
        temp.x = direction;
        transform.localScale = temp;
    }

    void DropEgg()
    {
        if(!attacked)
        {
            if (Physics2D.Raycast(transform.position,Vector2.down,Mathf.Infinity,playerLayer))
            {
                Instantiate(birdegg, new Vector3(transform.position.x, transform.position.y - 0.8f,transform.position.z),Quaternion.identity);
                attacked = true;
                anim.Play("bird_fly");
            }

        }
    }

    IEnumerator BirdDead(float TimeE)
    {
        yield return new WaitForSeconds(TimeE);
        gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            anim.Play("bird_dead");
            // for this think like recursion in second time 
            // it will collide with ground and we want it to pass the ground 
            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            CanMove = false;
            StartCoroutine(BirdDead(3f));
        }   
    }


}//class

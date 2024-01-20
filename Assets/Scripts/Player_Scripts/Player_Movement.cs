using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    public Rigidbody2D myBody;
    public Animator anim;
    public AudioSource AroundAudio;
    //public ControllerScript audioScript;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool jumped;

    private float jumpPower = 6f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        print(ControllerScript.SoundOnorOFf);
        if (ControllerScript.SoundOnorOFf)
        {
            AroundAudio.Play();
        }
        //IfSoundison();
    }

    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);

            ChangeDirection(1);

        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);

            ChangeDirection(-1);

        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
            anim.Play("PlayerIdeal");
        }

        anim.Play("PlayerWalk");

    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);

        if (isGrounded)
        {
            // and we jumped before
            if (jumped)
            {

                jumped = false;

                //anim.SetBool("jump", false);
            }
        }

    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);

                anim.Play("PlayerJump");
            }
        }
    }
    
    //public void IfSoundison()
    //{
      //  print(audioScript.SoundOnorOFf);
        //if (audioScript.SoundOnorOFf)
        //{
          //  print(audioScript.SoundOnorOFf);
            //AroundAudio.Play();
        //}
    //}

} // class



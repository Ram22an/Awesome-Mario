using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SurpriseBoxScripts : MonoBehaviour
{
    public Transform BotomCollsion;
    private Animator Anim;
    public LayerMask PlayerLayer;
    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private TextMeshProUGUI ScoreText;
    private bool CanAnimate = true;
    private char Score;
    public Score_Scripts ScoreGame;
    public AudioSource AudioS;
    private void Awake()
    {
        ScoreText = GameObject.Find("Coin Text")?.GetComponentInChildren<TextMeshProUGUI>();
        Anim =GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += .15f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        AnimateUpDown();

    }

    void CheckForCollision()
    {

        if (CanAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(BotomCollsion.position, Vector2.down, 0.1f, PlayerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    ScoreGame.ScoreCount++;
                    ScoreText.text="X "+ScoreGame.ScoreCount;
                    AudioS.Play();
                    Anim.Play("bonus_ideal");
                    startAnim = true;
                    CanAnimate = false;
                }
            }
        }
    }

    void AnimateUpDown()
    {
        if(startAnim)
        {
            transform.Translate(moveDirection*Time.smoothDeltaTime);
            if (transform.position.y >= animPosition.y)
            {
                moveDirection = Vector3.down;
            }
            else if(transform.position.y <= originPosition.y)
            {
                 startAnim = false;
            }
        }
    }



}//class

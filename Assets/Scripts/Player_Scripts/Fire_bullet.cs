using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_bullet : MonoBehaviour
{
    private float speed = 10f;
    private Animator anim;
    private bool Canmove;
    public AudioSource AudioS;
    public CircleCollider2D circleCollider;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Canmove = true;
        StartCoroutine(DisableBullet(1f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Canmove)
        {
            Vector3 Temp = transform.position;
            Temp.x += speed * Time.deltaTime;
            transform.position = Temp;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.tag == "beetle" || Target.gameObject.tag == "snail" || Target.gameObject.tag == "spider"
            || Target.gameObject.tag == "frog" || Target.gameObject.tag == "boss"||Target.gameObject.tag=="bird")
        {
            AudioS.Play();
            anim.Play("bullets_shooting");
            Canmove = false;
            StartCoroutine(DisableBullet(0.2f));
        }        
    }
}//class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Scripts : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiate;
    private Animator anim;
    private Vector2 temp;
    private string CouroutineName = "StartAttack";
    //public AudioSource AudioS;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        temp.x=attackInstantiate.position.x;
        temp.y = attackInstantiate.position.y;
        StartCoroutine(CouroutineName);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void BackToIdeal()
    {
        anim.Play("BossIdeal");
    }
    void Attack()
    {
        GameObject obj=Instantiate(stone,temp,Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f,-700f),0));
    }
    public void DeActivateAfterDelay(float delay)
    {
        StopCoroutine(CouroutineName);
        Invoke("DeActivateCoroutine", delay);
    }
    public void DeActivateCoroutine()
    {
        gameObject.SetActive(false);
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("BossAttack");
        //AudioS.Play();
        StartCoroutine(CouroutineName);
    }



}//class

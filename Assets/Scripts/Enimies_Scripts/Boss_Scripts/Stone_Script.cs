using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeActivate", 4f);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    void DeActivate()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false) ;
            collision.GetComponent<Player_Damage_Script>().DealDamage();
        }
    }

}//class

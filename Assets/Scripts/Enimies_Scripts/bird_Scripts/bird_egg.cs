using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_egg : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            collision.gameObject.GetComponent<Player_Damage_Script>().DealDamage();

        }
        gameObject.SetActive(false);
    }
}

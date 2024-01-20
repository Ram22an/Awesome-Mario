using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour
{
    public GameObject Fire_bullet;
    // Update is called once per frame
    void Update()
    {
        shootBullet(); 
    }

    void shootBullet()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            //(0,0,0) or Quaternion.identity for rotation
            GameObject bullet =Instantiate(Fire_bullet,transform.position,Quaternion.identity);
            bullet.GetComponent<Fire_bullet>().Speed*=transform.localScale.x;
        }
    }


}//class

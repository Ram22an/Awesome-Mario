using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_back : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr=GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1,1,1);
        float width = sr.sprite.bounds.size.x;
        float height=sr.sprite.bounds.size.y;
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth= worldHeight/Screen.height*Screen.width;
        Vector3 temp= transform.localScale;
        temp.x = worldWidth / width + 0.1f;
        temp.y = worldHeight / height + 0.1f;
        transform.localScale = temp;
    }



}//class

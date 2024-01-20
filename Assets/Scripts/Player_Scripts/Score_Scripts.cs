using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score_Scripts : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    private AudioSource AudioManager;
    public int ScoreCount = 0;
    private void Awake()
    {
        AudioManager=GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            collision.gameObject.SetActive(false);
            ScoreCount++;
            CoinText.text="X "+ScoreCount.ToString();
            AudioManager.Play();

        }
    }




}//class

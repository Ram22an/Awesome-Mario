using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_NewLevel : MonoBehaviour
{
    private AudioSource AudioManager;
    private bool LevelComplete = true;
    // Start is called before the first frame update
    void Awake()
    {
        AudioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            if (LevelComplete)
            {

                LevelComplete = false;
                AudioManager.Play();
                //LoadNewLevel(5f);
                StartCoroutine(LoadNewLevel(2f));
            }
        }
    }

    IEnumerator LoadNewLevel(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}//class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lava_Script : MonoBehaviour
{
    public AudioSource AudioS;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioS.Play();
            StartCoroutine(RestartLevel(3f));
        }
    }
    IEnumerator RestartLevel(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("FirstLevel");
    }



}//class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalWinning : MonoBehaviour
{
    public AudioSource Audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Audio.Play();
            //collision.gameObject.GetComponent<Animator>().Play("PlayerWinning");
            collision.gameObject.GetComponent<PlayerMovement>().myBody.velocity = Vector3.zero;
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<player_shoot>().enabled = false;
            StartCoroutine(RestartGame(6f));        
        }
    }
    IEnumerator RestartGame(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("UIScene");
    }
}

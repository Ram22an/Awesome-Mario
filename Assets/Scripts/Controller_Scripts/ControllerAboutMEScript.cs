using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControllerAboutMEScript : MonoBehaviour
{
    public AudioSource AroundAudio;
    public ControllerScript audioScript;
    void Start()
    {
        print(ControllerScript.SoundOnorOFf);
        if (ControllerScript.SoundOnorOFf)
        {
            AroundAudio.Play();
        }
    }
    public void Goback()
    {
        SceneManager.LoadScene("UIScene");
    }

   


}//class

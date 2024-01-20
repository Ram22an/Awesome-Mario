using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{
    public AudioSource Audio;
    public static bool SoundOnorOFf;
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
    //public void SoundOnoff()
    //{
      //  if (SoundOnorOFf)
        //{
          //  SoundOnorOFf = !SoundOnorOFf;
            //Audio.Play(); 
        //}
    //}
    public void isSoundonoroff()
    {
        SoundOnorOFf = !SoundOnorOFf;
        if (SoundOnorOFf)
        {
            Audio.Play();
        }
            
    }

    public void AboutMe()
    {
        SceneManager.LoadScene("AboutMe");
    }

}//class
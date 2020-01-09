using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuButtonsScript : MonoBehaviour {

    public void WakeUpTheBox()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("Wake Up The Box");
    }

    public void CookieHamster()
    {
        //Output this to console when the Button is clicked
        Debug.Log("999");
        SceneManager.LoadScene("Cookie Hamster");
    }

    public void EscapeTheRoom()
    {
        SceneManager.LoadScene("Escape The Room");
    }

    public void AnimationShowcase()
    {
        SceneManager.LoadScene("Animation Showcase");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

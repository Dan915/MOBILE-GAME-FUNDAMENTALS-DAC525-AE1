using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {
    void Start()
    {

    }

    public void MenuButton()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
		SceneManager.LoadScene("Menu");
    }

    public void NextButton()
    {
        //Output this to console when the Button is clicked
        Debug.Log("999");
  		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	[Header("OBJECTS")]
	public Transform loadingBar;
	public Transform textPercent;

	[Header("VARIABLES (IN-GAME)")]
	public bool isOn;
	[Range(0, 100)] public float currentPercent;
    public GameObject Win;


    void Update ()
	{
        var StartingPos = GameObject.Find("StartingPosition");
        var MrBox = GameObject.Find("MrBox");
        var distance = Vector2.Distance(StartingPos.transform.position,MrBox.transform.position);

        if (distance >0.1)
        {
            isOn = true;
        }

            if (currentPercent <= 100 && isOn)
            {
                currentPercent =  distance*100;
            }
        if (currentPercent > 100) currentPercent = 100;
        
            loadingBar.GetComponent<Image>().fillAmount = currentPercent / 100;
            textPercent.GetComponent<Text>().text = ((int)currentPercent).ToString("F0") + "%";

        if (currentPercent == 100) Win.SetActive(true);

        
	}
}
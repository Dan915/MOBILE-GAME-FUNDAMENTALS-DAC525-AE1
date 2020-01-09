using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour {

	public Image Star;
	bool starColleted;


	// Use this for initialization
	void Start ()
	{
		starColleted = false;
	}
	
	// Update is called once per frame
	void Update () {

		
		
	}
	    private void OnTriggerEnter2D(Collider2D other) 
		{
			Debug.Log("Collect star");
			Destroy(this.gameObject);
			starColleted = true;

			if (starColleted == true)
			{
				Debug.Log("change alpha");
				Star.GetComponent<Image>();
				Color alphaColor = Star.color;
				alphaColor.a = 1;
				Star.color = alphaColor;
			}
		}  
}

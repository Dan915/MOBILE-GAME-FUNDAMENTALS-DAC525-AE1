using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if(hit.collider != null && hit.collider.gameObject.tag == "Screw")	
		{
    		Debug.Log ("Target Name: " + hit.collider.gameObject.name);
			Destroy(hit.collider.gameObject);
		}

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Disable () 
	{
		if(Input.GetMouseButtonUp(0))	
			gameObject.SetActive(false);
		
	}
}

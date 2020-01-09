using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour {
	public Sprite screwdiver;
	public Sprite note;
	GameObject addItem;

	// Use this for initialization
	void Start () 
	{
		addItem = GameObject.Find("Inventory");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && hit.collider.gameObject.tag == "Backpack")	
			{
				addItem.GetComponent<AddToInventoryScript>().Add(screwdiver);
				addItem.GetComponent<AddToInventoryScript>().Add(note);
				Destroy(this.gameObject);
			}
		}		
	}
}

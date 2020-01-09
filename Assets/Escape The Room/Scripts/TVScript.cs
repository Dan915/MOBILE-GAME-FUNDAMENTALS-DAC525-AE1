using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVScript : MonoBehaviour {
	GameObject itemInHand;
	GameObject removeItem; 

	void Update ()
	{
		itemInHand = GameObject.Find("Inventory");
		removeItem =  GameObject.Find("Inventory").GetComponent<AddToInventoryScript>().Find("RemoteWithBattery");
		GameObject pickedItem = itemInHand.GetComponent<AddToInventoryScript>().pickedItem;

		if (Input.GetMouseButtonDown(0))
		{
			if(pickedItem == null || pickedItem.GetComponent<Image>().sprite == null)
			{
				return;
			}
			else if(pickedItem.GetComponent<Image>().sprite.name == "Remote")
			{
				Debug.Log("Can't Turn it on");
				return;
			}
			else if(pickedItem.GetComponent<Image>().sprite.name == "RemoteWithBattery")
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if(hit.collider.gameObject.tag == "TV")
				{
					Debug.Log("Turn it on");
					gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
					GameObject.Find("Inventory").GetComponent<AddToInventoryScript>().RemoveItem(removeItem);
				}
				return;
			}
		} 
	}
	/*
	
	if(itemInHand==null)
	{
		Debug.Log("I need something to cut this open");
		return;
	}

	else if(itemInHand !=null && itemInHand.name != "Screwdriver")
	{
		Debug.Log("Cant use this");
		return;
	}

	else if(itemInHand!=null && itemInHand.name == "Screwdriver")
	{
		Debug.Log("YAY");
		// do stuff
		return;
	}
	 */
}

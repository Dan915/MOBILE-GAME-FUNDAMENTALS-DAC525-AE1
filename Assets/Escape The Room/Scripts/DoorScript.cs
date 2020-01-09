using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

	GameObject itemInHand;
	GameObject removeItem; 
	public GameObject winScreen;
	public Sprite openedDoors;

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
			else if(pickedItem.GetComponent<Image>().sprite.name == "Key")
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if(hit.collider != null && hit.collider.gameObject.tag == "Finish")	
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = openedDoors;
					winScreen.SetActive(true);
				}
				return;
			}
		} 
	}
}

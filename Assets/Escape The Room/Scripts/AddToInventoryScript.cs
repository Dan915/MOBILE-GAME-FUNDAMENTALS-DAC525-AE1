using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class AddToInventoryScript : MonoBehaviour {

	GameObject Item;
	GameObject ItemSlot;
	Component ItemImage;
	public GameObject HelpfullMessage;
	public GameObject Note;
	Sprite m_Image;
	public Sprite RemoteWithBattery;
	public GameObject pickedItem = null;
	private GameObject[] BorderSlots;
	private List<Image> ImageSlots = new List<Image>();

	// GameObject itemInHand = GameObject.Find("Inventory").GetComponent<AddToInventoryScript>().pickedItem;
	// if(itemInHand == null || itemInHand.name != "Screwdriver") return;
	// Debug.Log("Used screwdriver on bag");

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
	void Start () 
	{
		foreach(Transform child in this.transform)
		{			
			if(!child.tag.Contains("UI_Slot")) continue;
			foreach(Transform sChild in child.transform)
			{
				if(!sChild.tag.Contains("UI_Border")) continue;
				foreach(Transform tChild in sChild.transform)
				{
					if(!tChild.tag.Contains("UI_Image")) continue;
					ImageSlots.Add(tChild.GetComponent<Image>());
				}
			}
		}
	
	foreach(Image item in ImageSlots)
	{
		Debug.Log(item.gameObject.name);
	}
		
	}
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if(hit.collider != null)	
		{
			Item = (hit.collider.gameObject);
			Debug.Log(Item);
			m_Image = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;

			if (hit.collider.gameObject.tag == "pickUP" && GameObject.Find("Note") == null)
			{
				Destroy(hit.collider.gameObject);

				Add(m_Image);
			}
		}

		}
	}

	public IEnumerator DisplayText(string text, float seconds)
	{
		// display stuff
		HelpfullMessage.SetActive(true);
		HelpfullMessage.transform.GetChild(0).gameObject.GetComponent<Text>().text = text;
		yield return new WaitForSeconds(seconds);
		HelpfullMessage.SetActive(false);
		// remove display
	}

	// Debug.Log("ABC");
	// public void Log(string text);

	public void PickItem()
	{
		pickedItem = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject;
		
		switch(pickedItem.GetComponent<Image>().sprite.name)
		{
			case  "Remote":
				Debug.Log("Get a battery");
				StartCoroutine(DisplayText("Get a battery", 5));
				break;
			case "RemoteWithBattery":
				Debug.Log("You can turn the tv on");
				StartCoroutine(DisplayText("You can turn the TV on", 5));
				break;
			case "Battery":
				StartCoroutine(DisplayText("You can use the battery with remote", 5));
				break;
			case "Note":
				Note.SetActive(true);
				StartCoroutine(DisplayText("Hmmm...  this has to be related to something...\n ... try finding the x", 3));
				break;
		}

			// public void Log(string toLog) { // bleble }
			// Debug.Log("ABC")

			/*
			GameObject battery = Find("Battery");
			
			
			
			 */

	}

	public GameObject Find(string ItemName)
	{
		foreach (var item in ImageSlots)
		{
			if(!item.enabled ||item.sprite == null || item.sprite.name != ItemName)
			continue;
			return item.gameObject;

		}
		return null;
	}

	public void Add(Sprite SpriteToAdd)
	{
		foreach (Image item in ImageSlots)
		{
			if(item.enabled || item.sprite != null)
			continue;
			item.enabled = true;
			item.sprite = SpriteToAdd;
			break;
		}

	}

	public void RemoveItem(GameObject itemToRemove)
	{
		itemToRemove.GetComponent<Image>().sprite = null;
		itemToRemove.GetComponent<Image>().enabled = false;
	}

	public void Battery()
	{
		if(pickedItem.GetComponent<Image>().sprite.name == "Battery") 
		{
			Debug.Log("Put In Remote");
			RemoveItem(Find("Remote"));
			RemoveItem(Find("Battery"));
			Add(RemoteWithBattery);

		}

	}



	/*
	
	if(!pickedItem.GetComponent<Image>().sprite.name == "Remote") return;
	turnTv.on();	
	
	 */
}

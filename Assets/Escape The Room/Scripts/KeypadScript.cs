using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadScript : MonoBehaviour {
	public GameObject Keypad;
	public GameObject addItem;
	public GameObject helpfullMessage;
	public Sprite Key;
	public string pin = "1025";
    public string input;
 
	public void Press1()
	{
		input = input + "1";
		Debug.Log("1");
	}
 	public void Press2()
	{
		input = input + "2";
	}
	public void Press3()
	{
		input = input + "3";
	}
	public void Press4()
	{
		input = input + "4";
	}
	public void Press5()
	{
		input = input + "5";
	}
	public void Press6()
	{
		input = input + "6";
	}
	public void Press7()
	{
		input = input + "7";
	}
	public void Press8()
	{
		input = input + "8";
	}
	public void Press9()
	{
		input = input + "9";
	}
	public void Press0()
	{
		input = input + "0";
		Debug.Log("0");
	}
	public void PressEnter()
	{
		Debug.Log(input);
		if (input == pin)
		{
		addItem.GetComponent<AddToInventoryScript>().Add(Key);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Destroy(GameObject.Find("Keypanel"));
		StartCoroutine(DisplayText("You found a key",2));
		}
	}
	public void Clear()
	{
		input = null;
	}
	void Start()
	{
		addItem = GameObject.Find("Inventory");
	}
		public IEnumerator DisplayText(string text, float seconds)
	{
		// display stuff
		helpfullMessage.SetActive(true);
		helpfullMessage.transform.GetChild(0).gameObject.GetComponent<Text>().text = text;
		yield return new WaitForSeconds(seconds);
		helpfullMessage.SetActive(false);
		// remove display
	}
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && GameObject.Find("Note") == null)
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && hit.collider.gameObject.name == "Safe")	
			{
				Keypad.SetActive(true);
				StartCoroutine(DisplayText("Pin consist of FOUR digits",3));
			}
		}		
	}
}

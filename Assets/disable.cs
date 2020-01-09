using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("zniszcz");
        gameObject.SetActive(false);
    }
}

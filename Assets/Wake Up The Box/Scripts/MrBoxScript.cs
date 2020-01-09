using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrBoxScript : MonoBehaviour {

	// Use this for initialization

	    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag.Contains("Sound"))
        {
			 AudioManager.TheAudioManager.PlaySFX("Falling");
        }
    }
}

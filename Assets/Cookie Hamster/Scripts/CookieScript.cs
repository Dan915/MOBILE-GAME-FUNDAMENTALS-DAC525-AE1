using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieScript : MonoBehaviour {
    public GameObject Win;
    
  
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Hamster")
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        	 AudioManager.TheAudioManager.PlaySFX("Eating");
            StartCoroutine(Example());
            Win.SetActive(true);		
        }
	}
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
		Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    private AudioSource audioSource;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         audioSource = GetComponent<AudioSource>();
         if( GameObject.FindGameObjectsWithTag("BGMusic").Length >1)
		{
			Destroy(this.gameObject);
		}
     }
	 public void Update()
	 {
		
	 }
 
     public void PlayMusic()
     {
         if (audioSource.isPlaying) return;
         audioSource.Play();
		 
     }
 
}

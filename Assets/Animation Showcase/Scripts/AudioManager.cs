using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public GameObject SFX_Prefab;

    public List<string> SFX_Names = new List<string>();
    public List<AudioClip> SFX_Clips = new List<AudioClip>();

    public Dictionary<string, AudioClip> SFX_Lib = new Dictionary<string, AudioClip>();

    public static AudioManager TheAudioManager;

	void Start ()
    {
        for (int i = 0; i < SFX_Names.Count; i++)
        {
            SFX_Lib.Add(SFX_Names[i], SFX_Clips[i]);
        }

        TheAudioManager = this;

    }
	
    public void PlaySFX(string Name)
    {
        if(SFX_Lib.ContainsKey(Name))
        {
            GameObject SFX = Instantiate(SFX_Prefab);
            AudioSource SRC = SFX.GetComponent<AudioSource>();
            SRC.clip = SFX_Lib[Name];
            SRC.Play();

            Destroy(SFX,SRC.clip.length);
        }
    }
}

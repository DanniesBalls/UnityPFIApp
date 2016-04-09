using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SphereAudio 
{

	GameObject soundsObj;
	AudioClip[] ac;
	AudioSource colliderSound;

	public SphereAudio()
	{
		ac = Resources.LoadAll<AudioClip> ("AudioFiles");
		//colliderSound = GameObject.Find ("Sphere").GetComponent<AudioSource> ();
	}

	public List<AudioClip> GetAudioOfType(string type)
	{
		List<AudioClip> tmpList = new List<AudioClip> ();
		for (int i = 0; i < ac.Length; i++) 
		{
			if (ac[i].name.StartsWith(type)) 
			{
				tmpList.Add( ac[i] );
			}
		}

		return tmpList;
	}

	public void AttachSound(string type, int rangeOfAudio, GameObject obj)
	{
		soundsObj = obj;
		colliderSound = soundsObj.GetComponent<AudioSource> ();

		if (GetAudioOfType (type).Count > rangeOfAudio)
			colliderSound.clip = GetAudioOfType (type) [rangeOfAudio];
		else
			colliderSound.clip = GetAudioOfType (type) [GetAudioOfType (type).Count - 1];

	}
	

	/*void OnCollisionEnter(Collision proj)
	{
		//Debug.Log (prim.clip);
		primaryAudioOut.Play ();
	}*/

}

using UnityEngine;
using System.Collections;

public class SphereCollisionDetection : MonoBehaviour {

	AudioSource collisionSound;

	void Start () 
	{
		collisionSound = GetComponent<AudioSource> ();
	}
	

	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision theThingThatHitMe)
	{
		Debug.Log(collisionSound.clip);
		collisionSound.Play ();
	}

}

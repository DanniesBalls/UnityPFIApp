using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionScript : MonoBehaviour {
	
	Rigidbody playerSim;

	Vector3 ViewPortMaxDist;
	float maxDistX;
	float maxDistY;

	Vector3 lastThingIhit;
	Vector3 DirToLastHitObject;

	void Start () 
	{
		playerSim = this.GetComponent<Rigidbody> ();
		ViewPortMaxDist = new Vector3 (1, 1, 0);
		maxDistX = Camera.main.ViewportToWorldPoint (ViewPortMaxDist).x - (this.GetComponent<SphereCollider> ().radius);
	    maxDistY = Camera.main.ViewportToWorldPoint (ViewPortMaxDist).y - (this.GetComponent<SphereCollider> ().radius);
	}
	
	// Update is called once per frame
	void Update () 
	{
		DirToLastHitObject = lastThingIhit - transform.position;
		DirToLastHitObject *= 10;
		
		if (transform.position.x > maxDistX || transform.position.y > maxDistY 
		    || transform.position.x < -maxDistX || transform.position.y < -maxDistY)
		{
			Debug.Log("out of bounds: " + this.gameObject);
			Destroy(this.gameObject);
			//playerSim.AddForce(DirToLastHitObject, ForceMode.Force);
		}


	}
	
	void OnCollisionEnter(Collision theThingIHit) 
	{
		if (theThingIHit.gameObject.tag == "MusicCollider" )
		{
			Debug.Log("Collision: " + this.gameObject.name);

			//This should happen when the object is destroyed
			MenuOptions.CurrentPlayer.Score++;

			Vector3 normalDir = theThingIHit.contacts[0].normal;
			playerSim.AddForce (normalDir * 15, ForceMode.Impulse);

			//Destroy (theThingIHit.gameObject);
			//lastThingIhit = theThingIHit.gameObject.transform.position;
		}


	}

	
	
}

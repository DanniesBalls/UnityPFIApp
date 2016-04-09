using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour {
	
	GameObject prefab;
	GameObject player;
	AudioSource onShot;
	
	void Start () 
	{
		prefab = Resources.Load ("Prefabs/Projectile") as GameObject;
		player = GameObject.Find ("Player");
		onShot = GameObject.Find ("ProjectileShooter").GetComponent<AudioSource> ();
		Debug.Log (prefab);
	}
	
	void Update () 
	{
	}
	
	int ammonition = 10;
	public int Ammonition
	{
		get {return ammonition;}
		set {ammonition = value;}
	}

	//function for shooting a projectile
	public void Shoot  () 
	{
		onShot.Play ();

		//where the cursor is located
		Vector3 cursorInWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.Log (cursorInWorldPos);
		
		//our player position
		Vector3 myPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		
		//a vector showing in which direction we should fire the projectile
		//normalize sets the magnitude to 1
		Vector3 direction = cursorInWorldPos - myPos;
		direction.Normalize ();
		
		//loads the projectile as a gameobject at the players position - quaternion corresponds to "no rotation"
		//Storing rigidbody reference
		GameObject projectile =  Instantiate (prefab, myPos, Quaternion.identity) as GameObject;
		Debug.Log (projectile);
		Rigidbody rb = projectile.GetComponent<Rigidbody> ();
		
		//adding velocity to the projectile
		rb.AddForce(direction * 30, ForceMode.Impulse); 
	}
	
	
	
	
}

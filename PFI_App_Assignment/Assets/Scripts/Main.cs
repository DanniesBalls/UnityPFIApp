using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {

	Player simon;
	// Use this for initialization
	void Start () 
	{
		simon = new Player ("Simon", 10);

	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject.Find("Text").GetComponent<Text>().text = "Ammo " + simon.Ammo;
		
		if (Input.GetMouseButtonDown (0)) 
		{
			simon.Shoot();
		}

		if (simon.OutOfAmmo ()) 
		{
			GameObject.Find("Text").GetComponent<Text>().text = "Out of Ammo!\nPress 'r' to reload";

			if(Input.GetKeyDown("r"))
				simon.Reload();
		}

	}
}

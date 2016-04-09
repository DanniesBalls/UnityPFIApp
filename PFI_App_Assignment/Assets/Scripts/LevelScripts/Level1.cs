using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1 : MonoBehaviour {

	GameObject playerObject;
	Player currentPlayer;
	ProjectileShooter weapon;

	GameObject createSpheres;
	IEnumerator SpawnSpheres;
	Text[] allText;

	void Start () 
	{
		currentPlayer = MenuOptions.CurrentPlayer;
		playerObject = GameObject.Find("Player");
		createSpheres = GameObject.Find("CreateSpheres");
		SpawnSpheres = createSpheres.GetComponent<RandomSpheres> ().SpawnSpheres ("Drum");
		weapon = GameObject.Find ("ProjectileShooter").GetComponent<ProjectileShooter> ();

		allText = GameObject.Find ("PlayerInfo").GetComponentsInChildren<Text> ();

		playerObject.GetComponent<SpriteRenderer> ().sprite = currentPlayer.PlayerSkin;
		currentPlayer.AttachWeapon (weapon);
		currentPlayer.AttachSound ( playerObject.GetComponent<AudioSource>() );

		StartCoroutine (SpawnSpheres);

	}
	
	// Update is called once per frame
	void Update () 
	{
		allText [1].text = "Score: " + currentPlayer.Score;
		allText[2].text = "Ammo: " + currentPlayer.Ammo;
		
		if (Input.GetMouseButtonDown (0)) 
		{
			currentPlayer.Shoot();
		}

		if (currentPlayer.OutOfAmmo ()) 
		{
			allText[2].text = "Out of Ammo!\nPress 'r' to reload";
			if(Input.GetKeyDown("r"))
				currentPlayer.Reload(10);
		}

	}
}

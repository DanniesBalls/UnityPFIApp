using UnityEngine;
using System.Collections;

public class Player
{
	//Attributes
	
	AudioSource fx;
	ProjectileShooter projectile;
	
	private string name;
	public string Name
	{
		get {return this.name;}
		set {this.name = value;}
	}
	
	private int ammo;
	public int Ammo
	{
		get {return this.ammo;}
		set {this.ammo = value;}
	}
	
	private int score;
	public int Score
	{
		get {return this.score;}
		set {this.score = value;}
	}
	
	//Constructor
	
	public Player (string name, int ammo)
	{
		this.Name = name; 
		this.Ammo = ammo;
		projectile = GameObject.Find ("Player").GetComponent<ProjectileShooter> ();
		fx = GameObject.Find ("Player").GetComponent<AudioSource> ();
	}
	
	//Function for shooting a projectile
	public bool OutOfAmmo()
	{
		if (this.Ammo == 0)
			return true;
		else
			return false;
	}

	public void Reload()
	{
		this.Ammo = 10;
	}

	public void Shoot()
	{
		if (this.Ammo > 0) 
		{
			projectile.Shoot ();
			ammo--;
		} 
		else 
		{
			Debug.Log("Reload Weapon");
		}


	}

	
}//end bracket

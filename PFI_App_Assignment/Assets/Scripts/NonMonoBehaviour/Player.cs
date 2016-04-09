using UnityEngine;
using System.Collections;

public class Player
{
	//Attributes
	ProjectileShooter weapon;
	AudioSource playerSounds;

	private Sprite playerSkin;
	public Sprite PlayerSkin
	{
		get {return this.playerSkin;}
		set {this.playerSkin = value;}
	}

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

	public Player()
	{

	}

	public Player(string name, Sprite skin)
	{
		this.Name = name;
		this.playerSkin = skin;
	}

	
	public Player (string name, int ammo)
	{
		this.Name = name; 
		this.Ammo = ammo;
	}

	public void AttachSound(AudioSource sound)
	{
		this.playerSounds = sound;
	}

	public void AttachWeapon(ProjectileShooter wep)
	{
		this.weapon = wep;
		this.Ammo = wep.Ammonition;
	}
	
	//Function for shooting a projectile
	public bool OutOfAmmo()
	{
		if (this.Ammo == 0)
			return true;
		else
			return false;
	}

	public void Reload(int amountOfAmmo)
	{
		this.Ammo = amountOfAmmo;
		playerSounds.Play ();
	}

	public void Shoot()
	{
		if (this.Ammo > 0) 
		{
			weapon.Shoot ();
			ammo--;
		} 

	}

	
}//end bracket

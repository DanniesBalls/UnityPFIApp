using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	static Player currentPlayer;
	public static Player CurrentPlayer
	{
		get {return currentPlayer;}
	}
	
	CanvasGroup[] canvasGroups;
	Button chooseLevelButton;

	void Start () 
	{
		canvasGroups = GameObject.Find ("Menu").GetComponentsInChildren<CanvasGroup> ();

		chooseLevelButton = GameObject.Find ("ChooseLevel").GetComponent<Button> ();
		chooseLevelButton.interactable = false;
	}


	void Update () 
	{
	
	}
	

	public void CreateDefaultPlayer(string player)
	{

		switch (player) 
		{

		case "Initialize":

			canvasGroups[0].interactable = true;

			break;

		case "Erik":

			currentPlayer = new Erik();
			chooseLevelButton.interactable = true;
			Debug.Log("Created: A default player with name " + currentPlayer.Name);

			break;

		case "Lars":

			currentPlayer = new Lars();
			chooseLevelButton.interactable = true;
			Debug.Log("Created: A default player with name " + currentPlayer.Name);

			break;
		
		}

	}

	public void InitilizeLevels()
	{
		canvasGroups[1].interactable = true;
	}

	public void ChooseLevel(string level)
	{
		Application.LoadLevel (level);
	}


}

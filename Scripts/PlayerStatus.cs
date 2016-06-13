using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus {

	private GamePlayer gamePlayer;
	private string playerName;
	private PlayerClass playerClass;

	private int myHealth;
	private int myMaxHealth;

	private int myMana;
	private int myMaxMana;

	private int Strength;
	private int Durability;
	private int Agility;
	private int Intelligence;

	private PlayerContainer playerContainer;

	private Dictionary<string, PlayerClass> classDictionary;
	private PlayerClass myClass;

	public PlayerStatus(int slot){
		loadCharacter (slot);
		GenerateCharacter ();
	}

	public void loadCharacter(int slot){
		playerContainer = PlayerContainer.Load (Path.Combine (Application.dataPath, "Resources/PlayerSave.xml"));
		gamePlayer = playerContainer.Players [slot];
			
		ClassContainer classContainer = ClassContainer.Load (Path.Combine (Application.dataPath, "Resources/Classes.xml"));
		classDictionary = new Dictionary<string, PlayerClass> ();
		for (int i = 0; i < classContainer.playerClass.Count; i++) {
			classDictionary [classContainer.playerClass [i].className] = classContainer.playerClass [i];
		}
	
		playerClass = classDictionary [gamePlayer.playerClass];

	}

	public void GenerateCharacter(){
		playerName = gamePlayer.playerName;
	}

	public string GetName(){
		return playerName;
	}

	public void SavePlayerStatus(){
		playerContainer.Save (Path.Combine (Application.dataPath, "Resources/PlayerSave.xml"));
	}


}

using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour {

	private PlayerStatus myPlayer;
	private PlayerStatus myEnemy;

	void Start () {
		myPlayer = new PlayerStatus (1);
		myPlayer.SavePlayerStatus ();
		Debug.Log (myPlayer.GetName ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

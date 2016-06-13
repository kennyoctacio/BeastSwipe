using System.Xml;
using System.Xml.Serialization;

public class GamePlayer {

	[XmlAttribute("slot")]
	public int slot;

	public string playerName;
	public string playerClass;

	public int head;
	public int armor;
	public int wep1;
	public int wep2;
	public int str;
	public int dur;
	public int agi;
	public int intel;

	/*
	public PlayerClass myClass;
	public PlayerWeapon myWeapon1;
	public PlayerWeapon myWeapon2;

	*/

}

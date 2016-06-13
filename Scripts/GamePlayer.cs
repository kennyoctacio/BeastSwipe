using System.Xml;
using System.Xml.Serialization;

public class GamePlayer {

	[XmlAttribute("slot")] // atribut
	public int slot;

	public string playerName;
	public string playerClass;

	public int head; // Armor Kepala
	public int armor; // Armor badan
	public int wep1; // Tangan 1
	public int wep2; // Tangan 2
	public int str; // Strength
	public int dur; // Durability
	public int agi; // Agility
	public int intel; // Intelligence

}

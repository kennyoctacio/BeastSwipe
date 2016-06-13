using System.Xml;
using System.Xml.Serialization;

public class PlayerClass {
	
	[XmlAttribute("name")]
	public string className;
	public int bHp;
	public int bMp;
	public int bStr;
	public int bDur;
	public int bAgi;
	public int bInt;

}

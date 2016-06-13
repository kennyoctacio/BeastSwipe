using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("PlayerSaves")]
public class PlayerContainer {

	[XmlArray("PlayerStatus"),XmlArrayItem("Player")]
	public GamePlayer[] Players;

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(PlayerContainer));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}

	public static PlayerContainer Load(string path)
	{
		var serializer = new XmlSerializer(typeof(PlayerContainer));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as PlayerContainer;
		}
	}

	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static PlayerContainer LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(PlayerContainer));
		return serializer.Deserialize(new StringReader(text)) as PlayerContainer;
	}
}

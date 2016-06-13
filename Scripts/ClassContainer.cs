using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ClassLists")]
public class ClassContainer {

	[XmlArray("Classes"),XmlArrayItem("Class")]
	public List<PlayerClass> playerClass;
	//public PlayerClass[] playerClass;

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(ClassContainer));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}

	public static ClassContainer Load(string path)
	{
		var serializer = new XmlSerializer(typeof(ClassContainer));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as ClassContainer;
		}
	}

	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static ClassContainer LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(ClassContainer));
		return serializer.Deserialize(new StringReader(text)) as ClassContainer;
	}
}

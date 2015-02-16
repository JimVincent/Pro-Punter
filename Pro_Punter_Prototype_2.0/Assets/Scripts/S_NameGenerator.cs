using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Is: A class that reads text documents
 * Has: A function to generate a random name
 * Use:	When assigning a new horse with a name
 * 
*/

public class S_NameGenerator : MonoBehaviour 
{
	static public S_NameGenerator inst;

	[SerializeField]
	private TextAsset textFirst;
	[SerializeField]
	private TextAsset textSecond;

	private List<string> namesFirst = new List<string>();
	private List<string> namesSecond = new List<string>();

	// Use this for initialization
	void Awake() 
	{
		// static instance
		inst = this;

		// occupy name lists
		namesFirst = Deserialize(textFirst);
		namesSecond = Deserialize(textSecond);

		string test = NewName();
		print(test);
	}

	// return a random name string
	public string NewName()
	{
		this.Shuffle(namesFirst);
		this.Shuffle (namesSecond);
		return namesFirst[0] + " " + namesSecond[0];
	}

	// deserializes the txt to a list of strings
	private List<string> Deserialize(TextAsset text)
	{
		string[] lines = text.text.Split('\n');
		List<string> tempL = new List<string>();
		foreach(string s in lines)
		{
			tempL.Add(s);
		}

		return tempL;
	}

	// Fischer Yates shuffle
	private void Shuffle(List<string> list)
	{
		for(int i = list.Count - 1; i > 0; i--)
		{
			string temp;
			int ranNum = Random.Range(0, i - 1);
			
			temp = list[i];
			list[i] = list[ranNum];
			list[ranNum] = temp;
		}
	}
}

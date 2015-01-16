using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_TXT_Data : MonoBehaviour 
{
	static public S_TXT_Data inst;

	public TextAsset text1;
	public TextAsset text2;

	static public List<string> names1 = new List<string>();
	static public List<string> names2 = new List<string>();

	// Use this for initialization
	void Awake() 
	{
		// static instance
		inst = this;

		// occupy name lists
		GenNames(text1, names1);
		GenNames(text2, names2);

		string test = NewName();
		print(test);
	}

	// return a random name string
	public string NewName()
	{
		this.Shuffle(names1);
		this.Shuffle (names2);
		return names1[0] + " " + names2[0];
	}

	// deserializes the txt to a list of strings
	public void GenNames(TextAsset txt, List<string> nList)
	{
		string[] lines = txt.text.Split('\n');
		foreach(string s in lines)
		{
			nList.Add(s);
		}
	}

	// Fischer Yates shuffle
	public void Shuffle(List<string> list)
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

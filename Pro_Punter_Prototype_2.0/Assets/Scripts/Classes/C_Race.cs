using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Is: A class that holds data for an individual race.
 * Has: Funcs to load and save member variables. race results for each horse.
 * Use: Allows access to race results for processing payOuts and archiving.
 * 
*/

public class C_Race : MonoBehaviour 
{
	public int mRaceNumber;
	public List<string> mHorseNames;
	public Dictionary<string,int> mResults; 
	
	public void SaveRace()
	{
		for(int i = 0; i < mHorseNames.Count; i++)
		{
			PlayerPrefs.SetString(mRaceNumber + "name" + i, mHorseNames[i]);
			PlayerPrefs.SetInt(mRaceNumber + "position" + i, mResults[mHorseNames[i]]);
		}
	}

	// load data from playerPrefs
	public void LoadRace(int raceNumber)
	{
		mRaceNumber = raceNumber;

		// iterate until mResults is filled
		int i = 0;
		bool end = false;
		while(!end)
		{
			// check if valid key exists
			if(PlayerPrefs.HasKey(mRaceNumber + "name" + i.ToString()))
			{
				string tempS = PlayerPrefs.GetString(mRaceNumber + "name" + i);
				int tempI = PlayerPrefs.GetInt(mRaceNumber + "position" + i);
				mResults.Add(tempS, tempI);
				mHorseNames.Add(tempS);
				i++;
			}
			else
				end = true;
		}
	}
}
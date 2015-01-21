using UnityEngine;
using System.Collections;

public class C_Horse : MonoBehaviour 
{
	public string mName;
	public int mSpeed;
	public int mStamina;
	public int mLuck;
	public int mValue;
	public bool isPlayer = false;
	public int mRacecount = 0;
	public int mRacesWon = 0;
	public int[] mLastThreeResults = new int[3];
	public int mLastRaceDay = 0;
	
	// randomly generated horse
	public void NewHorse()
	{
		// ensure the name doesn't already exist
		bool found = false;
		while(!found)
		{
			mName = S_TXT_Data.inst.NewName();
			if(!PlayerPrefs.HasKey(mName + "name"))
				found = true;
		}

		// set random stats
		mSpeed = Random.Range(30, 100);
		mStamina = Random.Range(30, 100);
		mLuck = Random.Range(30, 100);
		int tempVal = mSpeed * mStamina * mLuck;
		mValue = tempVal + (tempVal / 100) * mRacesWon;

		// zero race results
		for(int i = 0; i < 3; i++)
		{
			mLastThreeResults[i] = 0;
		}

		SaveHorse();
	}

	// load existing horse
	public void LoadHorse(string name)
	{
		if(PlayerPrefs.HasKey(name + "name"))
		{
			mName = name;
			mSpeed = PlayerPrefs.GetInt(name + "speed");
			mStamina = PlayerPrefs.GetInt(name + "stamina");
			mLuck = PlayerPrefs.GetInt(name + "luck");
			mValue = PlayerPrefs.GetInt(name + "value");
			mRacecount = PlayerPrefs.GetInt(name + "raceCount");
			mRacesWon = PlayerPrefs.GetInt(name + "racesWon");
			mLastRaceDay = PlayerPrefs.GetInt(name + "lastRaceDay");
			for(int i = 0; i < 3; i++)
			{
				mLastThreeResults[i] = PlayerPrefs.GetInt(name + "lastThreeResults" + i);
			}
		}
		else
			Debug.LogError("No saved data for horse name :" + name);
	}

	// update saved horse data
	public void SaveHorse()
	{
		PlayerPrefs.SetInt(name + "speed", mSpeed);
		PlayerPrefs.SetInt(name + "stamina", mStamina);
		PlayerPrefs.SetInt(name + "luck", mLuck);
		PlayerPrefs.SetInt(name + "value", mValue);
		PlayerPrefs.SetInt(name + "raceCount", mRacecount);
		PlayerPrefs.SetInt(name + "racesWon", mRacesWon);
		PlayerPrefs.SetInt(name + "lastRaceDay", mLastRaceDay);
		for(int i = 0; i < 3; i++)
		{
			PlayerPrefs.GetInt(name + "lastThreeResults" + i, mLastThreeResults[i]);
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 *
 * Is: A class that stores all completed races
 * Has: Functions to get, add, load and save races.
 * Use: For accessing previous race results and producing stats
 * 
*/

public class S_BookKeeper : MonoBehaviour 
{
	private Dictionary<int, C_Race> raceArchive;

	// returns the race requested by race number
	public C_Race GetRace(int raceNumber)
	{
		return raceArchive[raceNumber];
	}

	// returns the amount of races completed
	public int GetRaceCount()
	{
		return raceArchive.Count;
	}

	// adds a new entry to the local dictionary
	public void NewEntry(C_Race entry)
	{
		raceArchive.Add(raceArchive.Count + 1, entry);
	}

	// returns the horse place in the given race
	public int GetHorseResult(string name, int raceNumber)
	{
		return raceArchive[raceNumber].mResults[name];
	}

	// loads all completed races and stores in local dictionary
	public void LoadBook()
	{
		// retrive total race count
		int count = PlayerPrefs.GetInt("BKRaceCount");

		// load each race and add to dictionary
		for(int i = 1; i <= count; ++i)
		{
			C_Race tempR = null;
			tempR.LoadRace(i);
			raceArchive.Add(count, tempR);
		}
	}

	// saves all completed races and the current race count
	public void SaveBook()
	{
		// save race count to aid in loading loop
		PlayerPrefs.SetInt("BKRaceCount", raceArchive.Count);

		// save each race
		for(int i = 1; i <= raceArchive.Count; ++i)
		{
			raceArchive[i].SaveRace();
		}
	}
}
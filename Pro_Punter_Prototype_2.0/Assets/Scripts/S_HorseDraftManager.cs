using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Is: a storage place for all created horses retired and active ones
 * Has: A function to return a horse by name. Loads horses or creates horses on STart
 * Use:	to retrieve a horse for accessing data or entering into a race.
 *
*/

public class S_HorseDraftManager : MonoBehaviour 
{
	public static S_HorseDraftManager inst;

	public int amountInDraft;
	public int racesUntilRetired;

	private List<C_Horse> activeHorses;
	private List<C_Horse> retiredHorses;
	private List<string> horseNames;		// for loading purposes

	void Awake()
	{
		inst = this;
	}

	void Start()
	{
		// check if any saved data
		if(!PlayerPrefs.HasKey("HDM0"))
		{
			// first time playing - need new horses
			for(int i = 0; i < amountInDraft; i++)
			{
				// create new and add values
				C_Horse newTemp = new C_Horse();
				newTemp.NewHorse();
			}
		}
		else
		{
			LoadDraft();
		}
	}

	// checks and removes any horses due for retirement (buffer with mLuck)
	private void CheckForRetired()
	{
		for (int i = 0; i < activeHorses.Count; i++)
		{
			if(activeHorses[i].mRaceList.Count == racesUntilRetired)
			{
				// offer chance of not retiring in respects to mLuck
				int diceRoll = Mathf.RoundToInt(Random.Range(0, 100));

				if(diceRoll > activeHorses[i].mLuck)
				{
					// out of luck and time to retire
					retiredHorses.Add(activeHorses[i]);
					activeHorses.Remove(activeHorses[i]);

					// make new horse to replace last
					C_Horse temp = new C_Horse();
					temp.NewHorse();
					activeHorses.Add(temp);
				}
			}
		}
	}
	
	public void UpdateHorseStats(string name, C_Race race)
	{
		// increment race count
		C_Horse tempH = GetHorse(name);
		tempH.mRacecount++;

		// add race number to list
		tempH.mRaceList.Add(race.mRaceNumber);

		// incerement if won
		if(race.mResults[name] == 1)
			tempH.mRacesWon++;
	}

	public C_Horse GetHorse(string name)
	{
		C_Horse tempH = null;

		// check active list first
		for(int i = 0; i < activeHorses.Count; i++)
		{
			if(name == activeHorses[i].name)
				tempH = activeHorses[i];
		}

		// check retired list next
		for(int j = 0; j < retiredHorses.Count; j++)
		{
			if(name == retiredHorses[j].mName)
				tempH = retiredHorses[j];
		}

		return tempH;
	}

	// loads and occupies horse lists from saved data
	public void LoadDraft()
	{
		for(int i = 0; i < amountInDraft; i++)
		{
			horseNames.Add(PlayerPrefs.GetString("HDM" + i));
			C_Horse tempH = new C_Horse();
			tempH.LoadHorse(horseNames[i]);

			if(tempH.isRetired)
				retiredHorses.Add(tempH);
			else
				activeHorses.Add(tempH);
		}
	}
}

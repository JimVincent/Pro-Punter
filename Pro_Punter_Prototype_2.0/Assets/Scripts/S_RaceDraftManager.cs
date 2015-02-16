using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_RaceDraftManager : MonoBehaviour 
{
	private List<C_Race> raceDraft = new List<C_Race>();
	private int currentRaceNumber;

	// returns an x sized array of races after the current
	public C_Race[] GetNextRaces(int amount)
	{
		C_Race[] tempA = new C_Race[amount];

		for(int i = 0; i < amount; ++i)
		{
			tempA[i] = raceDraft[currentRaceNumber + 1 + i];
		}

		return tempA;
	}

	// Getter
	public int GetCurrentRaceNumber()
	{
		return currentRaceNumber;
	}

	public void AddNewRace(int amount)
	{
		for(int i = 0; i < amount; ++i)
		{

		}
	}

	public void SaveDraft()
	{

	}

	public void LoadDraft()
	{

	}
}

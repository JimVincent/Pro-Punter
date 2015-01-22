using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_HorseGrid_Manager : MonoBehaviour 
{
	static public S_HorseGrid_Manager inst;
	public List<C_Horse> horseList = new List<C_Horse>();	// horses to choose from
	public List<C_Horse> raceList = new List<C_Horse>();	// horses in race

	void Awake()
	{
		inst = this;

		// load saved horses
		for(int i = 1; i < S_GameManager.newHorseLimit + 1; i++)
		{
			if(PlayerPrefs.HasKey("savedHorses" + i.ToString()))
			{
				C_Horse tempH = new C_Horse();
				tempH.LoadHorse(PlayerPrefs.GetString("savedHorses" + i.ToString()));
				horseList.Add(tempH);
			}
			else
				break;
		}
	}

	// return random list of available horses
	public List<C_Horse> GetRacers(int amount)
	{
		List<C_Horse> tempL;
		ShuffleHorses();

		for(int i = 0; i < amount; i++)
		{
			if(!horseList[i].mLastRaceDay ==  S_GameManager.inst.day)
				tempL.Add(horseList[i]);
		}
	}
	
	// adds new horses to the horseList
	public void AddHorses(int amount)
	{
		for(int i = 0; i < amount; i++)
		{
			C_Horse tempH = new C_Horse();
			tempH.NewHorse();
			horseList.Add(tempH);
			PlayerPrefs.SetString("savedHorses" + horseList.Count.ToString(), tempH.mName);
		}
	}

	private void ShuffleHorses(List<C_Horse> list)
	{
		C_Horse tempH;
		for(int i = list.Count - 1; i = 0; i--)
		{
			int random = Random.Range(0, i - 1);
			tempH = list[random];
			list[random] = list[i];
			list[i] = tempH;
		}
	}
}
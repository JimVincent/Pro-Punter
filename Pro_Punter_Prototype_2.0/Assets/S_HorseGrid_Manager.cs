using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_HorseGrid_Manager : MonoBehaviour 
{
	static public S_HorseGrid_Manager inst;

	public int gridSize = 8;
	public int racesPerDay = 4;

	private bool fullRace = false;
	public List<C_Horse> horseList = new List<C_Horse>();	// horses to choose from

	public List<C_Horse> raceList = new List<C_Horse>();			// horses in race

	public int newHorseLimit = 100;
	public int newHorsesPerDay = 2;


	void Awake()
	{
		inst = this;

		// load saved horses
		for(int i = 1; i < newHorseLimit + 1; i++)
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

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Adds new horses to horseList per day
	public void FillRoster()
	{
		if(S_GameManager.inst.day <= 1)
		{
			// create all new horses
			AddHorse(gridSize * racesPerDay);
			ShuffleHorses();
		}
		else
		{
			AddHorse(newHorsesPerDay);
		}
	}

	// generates a new horse
	public void AddHorse(int amount)
	{
		for(int i = 0; i < amount; i++)
		{
			C_Horse tempH = new C_Horse();
			tempH.NewHorse();
			horseList.Add(tempH);
			PlayerPrefs.SetString("savedHorses" + horseList.Count.ToString(), tempH.mName);
		}
	}

	public void ShuffleHorses()
	{

	}
}

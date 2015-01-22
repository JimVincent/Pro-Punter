using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class S_GameManager : MonoBehaviour 
{
	static public S_GameManager inst;

	public int day = 1;

	public enum State {preRace, race, finRace};
	static public State gameState;

	public int gridSize = 8;
	public int racesPerDay = 4;
	public int newHorseLimit = 100;
	public int newHorsesPerDay = 2;
	
	void Awake()
	{
		inst = this;
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void NewDay()
	{
		day++;
		PlayerPrefs.SetInt("day", day);
	}


}

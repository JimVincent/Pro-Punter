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


}

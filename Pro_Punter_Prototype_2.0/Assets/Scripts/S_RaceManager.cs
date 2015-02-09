using UnityEngine;
using System.Collections;

/*
 * Will look after the logic of the race section. From loading the horses into the gate and switching the mic states
 * to prenouncing the winner at the end.
 * 
 * It will not control the horses directly (apart from loading them into the gate) but will tell them when to go.
*/

public class S_RaceManager : MonoBehaviour 
{

	public float horseLoadSpeed = 0.1f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}


	/*
	 * Takes an array of horses and moves them into starting position based on there mSpeed.
	 * The MicInput will also be set to calibration for this duration
	*/
	public void LoadUpGates(C_Horse[] horses)
	{
		// move the horses from left of screen into gates
		for(int i = 0; i < horses.Length; i++)
		{
			// Switch to calibration
			//S_MicInput.State = S_MicInput.State.calibrate;

			Vector3 hPos = horses[i].transform.position;
			horses[i].transform.position = new Vector3(hPos.x + horses[i].mSpeed * horseLoadSpeed *Time.deltaTime, hPos.y, hPos.z);
		}
	}
}

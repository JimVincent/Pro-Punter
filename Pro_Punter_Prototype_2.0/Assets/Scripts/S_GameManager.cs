using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_GameManager : MonoBehaviour 
{
	public S_MicInput mic;

	public enum State {preRace, race, finRace};
	static public State gameState;

	public Text calibrating;
	public Text quiet;
	public Text countDown;
	float timer = 0.0f;

	float tempTimer = 4.0f;

	// Use this for initialization
	void Start () 
	{
		gameState = State.finRace;
	}
	
	// Update is called once per frame
	void Update () 
	{



		switch(gameState)
		{
		case State.preRace:

			timer += Time.deltaTime;
			if(timer < 1.0f)
				calibrating.enabled = true;
			else
			{
				calibrating.enabled = false;
				if(timer >= 1.2f)
					timer = 0.0f;
			}

			tempTimer -= Time.deltaTime;
			countDown.text = Mathf.RoundToInt(tempTimer).ToString();
			if(tempTimer <= 0.0f)
			{
				gameState = State.race;
				calibrating.enabled = false;
				quiet.enabled = false;
				countDown.enabled = false;
			}


			S_MicInput.micState = S_MicInput.State.calibrate;
			break;

		case State.race:

			S_MicInput.micState = S_MicInput.State.race;
			break;

		case State.finRace:
			calibrating.enabled = false;
			break;
		}
	}

	public void StartCali()
	{
		mic.enabled = true;
		gameState = State.preRace;
		calibrating.enabled = true;
		countDown.enabled = true;
	}
}

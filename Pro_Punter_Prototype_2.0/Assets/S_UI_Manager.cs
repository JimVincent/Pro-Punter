using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_UI_Manager : MonoBehaviour 
{
	public enum State {menu, options, betting, racing, results};

	// volume bar vars
	public RectTransform volumeBar;
	public GameObject[] vBarStars;
	private float vBarMaxX;
	private bool whip = false;
	private float whipDuration;
	private float whipTimer = 0.0f;

	public State UIState;

	[System.Serializable]
	public class UIScreen
	{
		public State name;
		public Canvas canvas;
	}

	public UIScreen[] screens;

	// Use this for initialization
	void Start () 
	{
		vBarMaxX = volumeBar.localScale.x;
		volumeBar.gameObject.renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(UIState == State.racing)
		{

		}
		else if(UIState == State.betting)
		{

		}
		// update volume bar
		if(S_MicInput.currentVolume <= S_MicInput.currentPeak && !whip)
			volumeBar.localScale = new Vector3(vBarMaxX * (S_MicInput.currentVolume / S_MicInput.currentPeak), volumeBar.localScale.y, volumeBar.localScale.z);
		else
		{
			whip = true;
			volumeBar.gameObject.renderer.material.color = Color.cyan;

		}
	}

	public void SwitchUI(State newState)
	{
		UIState = newState;

		switch (newState)
		{
		case State.menu:
			SwitchOnUI(State.menu);
			break;

		case State.options:
			SwitchOnUI(State.options);
			break;

		case State.betting:
			SwitchOnUI(State.betting);
			break;

		case State.racing:
			SwitchOnUI(State.racing);
			break;

		case State.results:
			SwitchOnUI(State.results);
			break;

		default:
			Debug.LogError("Something broke in SwitchUI");
			break;
		}
	}

	private void SwitchOnUI(State name)
	{
		for(int i = 0; i < screens.Length; i++)
		{
			if(screens[i].name == name)
				screens[i].canvas.enabled = true;
			else
				screens[i].canvas.enabled = false;
		}
	}

	public void WhipUI()
	{
		whipTimer += Time.deltaTime;
		if(whipTimer >= whipDuration)
		{
			whip = false;
			whipTimer = 0.0f;
			volumeBar.gameObject.renderer.material.color = Color.green;
		}
	}
}

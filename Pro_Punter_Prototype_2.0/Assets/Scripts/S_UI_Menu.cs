using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_UI_Menu : MonoBehaviour {

	public enum State {main, options, exit};
	public enum Button {start, options, exit, back};

	[System.Serializable]
	public class UIScreen
	{
		public State name;
		public Canvas canvas;
	}

	public UIScreen[] screens;
	public Slider[] sliders;

	// Use this for initialization
	void Start () 
	{
		SwitchScreen(State.main);
	}

	// switches on active state and switches off rest
	public void SwitchScreen(State newState)
	{
		for(int i = 0; i < screens.Length; i++)
		{
			if(newState == screens[i].name)
			{
				screens[i].canvas.enabled = true;
			}
			else
			{
				screens[i].canvas.enabled = false;
			}
		}
	}

	public void ButtonPress(Button button)
	{
		switch(button)
		{
		// initiate start game sequence
		case Button.start:

			break;
		
		// switch canvas's
		case Button.options:
			SwitchScreen(State.options);
			break;

		// quit the game
		case Button.exit:
			Application.Quit();
			break;

		// save options data and switch to main
		case Button.back:
			SwitchScreen(State.main);
			break;
		}
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class S_MicInput : MonoBehaviour 
{
	private float micSensitivity = 1000;
	private float holdTime = 1.0f;
	private float holdTimer = 0.0f;
	
	private List<float> caliList = new List<float>();	// tracking calibration input
	private bool applyCalibration = false;
	private float calibration = 0.0f;
	
	public enum State{standby, calibrate, race};

	static public State micState;
	static public float currentPeak = 0.0f;				// highest current volume held
	static public float currentVolume = 0.0f;

	// Use this for initialization
	void Start () 
	{
		micState = State.calibrate;
		audio.clip = Microphone.Start(null, true, 10, 44100);
		audio.loop = true; // Set the AudioClip to loop
		audio.mute = true; // Mute the sound, we don't want the player to hear it
		while (!(Microphone.GetPosition("") > 0))
		{
			if(Microphone.devices.Length == 0)
			{
				Debug.LogError("No Mic Detected");
				break;
			}
		} // Wait until the recording has started
		audio.Play(); // Play the audio source!
	}
	
	// Update is called once per frame
	void Update () 
	{
		// active mic reading
		float loudness = GetAveragedVolume() * micSensitivity - calibration;
		if(loudness < 0.0f)
			loudness = 0.0f;

		switch(micState)
		{
		case State.calibrate:

				caliList.Add(loudness);
			break;

		case State.race:

			// apply calibration once
			if(!applyCalibration)
			{
				float tempTotal = 0.0f;
				for(int i = 0; i < caliList.Count; i++)
				{
					tempTotal += caliList[i];
				}
				calibration = tempTotal / caliList.Count;	// average in respect to cali cycles
				applyCalibration = true;
			}

			// update currentPeak after held for x seconds
			if(currentVolume > currentPeak)
			{
				holdTimer += Time.deltaTime;
				if(holdTimer > holdTime)
				{
					currentPeak = currentVolume;
					holdTimer = 0.0f;
				}
			}
			else
				holdTimer = 0.0f;
			
			// update currentVolume with a lerp (faster up than down)
			if(loudness > currentVolume)
				currentVolume = Mathf.Lerp(currentVolume, loudness, 0.01f);
			else
				currentVolume = Mathf.Lerp(currentVolume, loudness, 0.001f);
			break;
		}
	}

	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		audio.GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
	}
}
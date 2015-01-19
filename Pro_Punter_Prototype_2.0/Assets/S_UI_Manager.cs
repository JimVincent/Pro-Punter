using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_UI_Manager : MonoBehaviour 
{
	// volume bar vars
	public RectTransform volumeBar;
	public GameObject[] vBarStars;
	private float vBarMaxX;
	private bool whip = false;
	private float whipDuration;
	private float whipTimer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		vBarMaxX = volumeBar.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// update volume bar
		if(S_MicInput.currentVolume <= S_MicInput.currentPeak && !whip)
			volumeBar.localScale = new Vector3(vBarMaxX * (S_MicInput.currentVolume / S_MicInput.currentPeak), volumeBar.localScale.y, volumeBar.localScale.z);
		else
		{
			whip = true;
			volumeBar.gameObject.renderer.material.color = Color.cyan;

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

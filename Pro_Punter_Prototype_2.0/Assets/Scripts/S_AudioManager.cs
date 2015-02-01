using UnityEngine;
using System.Collections;

public class S_AudioManager : MonoBehaviour {

	static public S_AudioManager inst;

	public enum Type {SFX, Music};

	[System.Serializable]
	public class ASource
	{
		public AudioSource aSource;
		public Type type;
		public float original = 1.0f;
	}

	public ASource[] aSources;

	private float sfxVolume = 1.0f;
	private float musicVolume = 1.0f;

	void Awake()
	{
		inst = this;
	}

	void Start()
	{
		for(int i = 0; i < aSources.Length; i++)
		{
			aSources[i].original = aSources[i].aSource.volume;
		}
	}

	public void UpdateVolumes()
	{
		sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
		musicVolume = PlayerPrefs.GetFloat("MusicVolume");

		for(int i = 0; i < aSources.Length; i++)
		{
			float newVolume;

			if(aSources[i].type == Type.Music)
			{
				newVolume = aSources[i].original * PlayerPrefs.GetFloat("MusicVolume");
			}
			else
			{
				newVolume = aSources[i].original * PlayerPrefs.GetFloat("SFXVolume");
			}

			aSources[i].aSource.volume = newVolume;
		}
	}

	public void SaveMusicVolume(int music)
	{
		PlayerPrefs.SetFloat("musicVolume", music / 10);
		UpdateVolumes();
	}

	public void SaveSFXVolume(int sfx)
	{
		PlayerPrefs.SetFloat("SFXVolume", sfx / 10);
		UpdateVolumes();
	}
}

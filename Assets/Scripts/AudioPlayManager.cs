using MH2B.Utilities;
using UnityEngine;

public class AudioPlayManager : PersistentSingleton<AudioPlayManager>
{
	public bool CanPlayMusic
	{
		get { return PlayerPrefs.GetInt(GeneralParams.Music) == 1 ? true : false; }
		set {  PlayerPrefs.SetInt(GeneralParams.Music, value ? 1 : 0); OnPlayMusicChanged?.Invoke(value); }
	}
	public System.Action<bool> OnPlayMusicChanged;



	public bool CanPlaySoundTrack
	{ 
		get { return PlayerPrefs.GetInt(GeneralParams.SoundTrack) == 1 ? true : false; } 
		set { PlayerPrefs.SetInt(GeneralParams.SoundTrack, value ? 1 : 0); OnPlaySoundTrackChanged?.Invoke(value); }
	}
	public System.Action<bool> OnPlaySoundTrackChanged;

	protected override void Awake()
	{
		base.Awake();
		Setup();
	}

	private void Setup()
	{
		if (!PlayerPrefs.HasKey(GeneralParams.Music))
		{
			CanPlayMusic = true;
		}

		if (!PlayerPrefs.HasKey(GeneralParams.SoundTrack))
		{
			CanPlaySoundTrack = true;
		}
	}

}

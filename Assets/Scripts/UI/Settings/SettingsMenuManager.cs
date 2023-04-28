using MH2B.Utilities;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuManager : MonoBehaviour
{

	[SerializeField] private GameObject musicOnBtn;
	[SerializeField] private GameObject musicOffBtn;
	[SerializeField] private GameObject soundTrackOnBtn;
	[SerializeField] private GameObject soundTrackOffBtn;

	[SerializeField] private TMP_InputField nameInputField;
	[SerializeField] private TMP_InputField ageInputField;
	[SerializeField] private TMP_InputField phoneInputField;


	private void Awake()
	{
		Setup();
	}

	private void Setup()
	{
		SwitchMusicBtns(AudioPlayManager.Instance.CanPlayMusic);
		SwitchSoundTrackBtns(AudioPlayManager.Instance.CanPlaySoundTrack);

		if (PlayerPrefs.HasKey(GeneralParams.Name))
		{
			nameInputField.text = PlayerPrefs.GetString(GeneralParams.Name);
		}
		if (PlayerPrefs.HasKey(GeneralParams.Age))
		{
			ageInputField.text = PlayerPrefs.GetString(GeneralParams.Age);
		}
		if (PlayerPrefs.HasKey(GeneralParams.Phone))
		{
			phoneInputField.text = PlayerPrefs.GetString(GeneralParams.Phone);
		}
	}

	private void SwitchMusicBtns(bool value)
	{
		musicOnBtn.SetActive(value);
		musicOffBtn.SetActive(!value);
		AudioPlayManager.Instance.CanPlayMusic = value;
	}

	private void SwitchSoundTrackBtns(bool value)
	{
		soundTrackOnBtn.SetActive(value);
		soundTrackOffBtn.SetActive(!value);
		AudioPlayManager.Instance.CanPlaySoundTrack = value;
	}

	public void SwitchMusicClicekd(bool value)
    {
		SwitchMusicBtns(value);
	}

	public void SwitchSoundTrackClicekd(bool value)
	{
		SwitchSoundTrackBtns(value);
	}

	public void NameApply()
	{
		PlayerPrefs.SetString(GeneralParams.Name, nameInputField.text);
	}

	public void AgeApply()
	{
		PlayerPrefs.SetString(GeneralParams.Age, ageInputField.text);
	}

	public void PhoneApply()
	{
		PlayerPrefs.SetString(GeneralParams.Phone, phoneInputField.text);
	}

	public void LinkdinClicked()
	{
		OpenUrl("https://www.linkedin.com/company/skillent-ir");
	}

	public void InstagramClicked()
	{
		OpenUrl("https://instagram.com/skillentstudio?igshid=YmMyMTA2M2Y=");
	}

	private void OpenUrl(string url)
	{
		Application.OpenURL(url);
	}

	public void BackBtnClicked()
	{
        SceneManager.LoadScene("NewMenu");
    }

	public void SettingsBtnClicked()
	{

	}
}

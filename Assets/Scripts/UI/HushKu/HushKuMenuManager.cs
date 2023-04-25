using MH2B.GameModules.ResourceManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HushKuMenuManager : MonoBehaviour
{
	public List<MiniGame> MiniGames;

	[SerializeField] private Image icon;
    [SerializeField] private ProgressLightsSwitcher progressLightsSwitcher;
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject prevBtn;
    private int gameIndex = 0;

	private void Start()
	{
		Init();
	}

	private void Init()
	{
		ChangeGame(gameIndex);
	}

	public void ChangeGame(int value)
    {
		gameIndex += value;
		if (MiniGames.Count <= gameIndex || gameIndex < 0) { gameIndex -= value; return; }

		MiniGame miniGame = MiniGames[gameIndex];
		icon.sprite = miniGame.Icon;
		prevBtn.SetActive(false);
		nextBtn.SetActive(false);

		if (gameIndex > 0)
			prevBtn.SetActive(true);
		if(gameIndex < MiniGames.Count)
			nextBtn.SetActive(true);

		progressLightsSwitcher.SetProgress(ResourcesUtilities.GetValue(miniGame.EasyResourceName));
	}

	public void ChangeDifficulty(int miniGameDifficulty)
	{
		MiniGame miniGame = MiniGames[gameIndex];
		switch (miniGameDifficulty)
		{
			case 0:
				progressLightsSwitcher.SetProgress(ResourcesUtilities.GetValue(miniGame.EasyResourceName));
				break;
			case 1:
				progressLightsSwitcher.SetProgress(ResourcesUtilities.GetValue(miniGame.EasyResourceName));
				break;
			case 2:
				progressLightsSwitcher.SetProgress(ResourcesUtilities.GetValue(miniGame.EasyResourceName));
				break;
		}
	}

}

using MH2B.Rewarding;
using RTLTMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MiniGameDifficulty
{
    Easy,
    Normal,
    Hard
}

[Serializable]
public class MiniGame
{
    public string ResourceName;
    [TextArea] public string Description;
    public Sprite Icon;
    public string Scene;
    public string EasyResourceName;
	public string NormalResourceName;
	public string HardResourceName;
}

public class MiniGamesMenuManager : MonoBehaviour
{
    public List<MiniGame> MiniGames;

    public Image miniGame1Icon;
    public RTLTextMeshPro miniGame1Text;
    public Button miniGame1Button;
	public Image miniGame2Icon;
	public RTLTextMeshPro miniGame2Text;
	public Button miniGame2Button;

	private void Awake()
	{
        if (MiniGames.Count < 2) return;

        int rand1 = UnityEngine.Random.Range(0, MiniGames.Count);
        int rand2 = UnityEngine.Random.Range(0, MiniGames.Count);
        while(rand2 == rand1)
        {
			rand2 = UnityEngine.Random.Range(0, MiniGames.Count);
		}

        MiniGame miniGame1 = MiniGames[rand1];
		miniGame1Icon.sprite = miniGame1.Icon;
        miniGame1Text.text = miniGame1.Description;
		miniGame1Button.onClick.RemoveAllListeners();
        miniGame1Button.onClick.AddListener(() => MiniGameClicked(miniGame1.Scene));

		MiniGame miniGame2 = MiniGames[rand2];
		miniGame2Icon.sprite = miniGame2.Icon;
		miniGame2Text.text = miniGame2.Description;
		miniGame2Button.onClick.RemoveAllListeners();
		miniGame2Button.onClick.AddListener(() => MiniGameClicked(miniGame2.Scene));
	}

    public void MiniGameClicked(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}

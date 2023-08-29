using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuManager : MonoBehaviour
{
    [SerializeField] private LevelsContainer levelsContainer;
	[SerializeField] private Transform content;
	[SerializeField] private GameObject levelsParent;
	[SerializeField] private LevelItemFrame levelItemFrame;
	[SerializeField] private int maxLevelsParentCapacity = 10;

	private bool canOpenLevelScenes = true;

	private void Awake()
	{
		LevelItemFrame.onOpenLevelClicked += OnOpenLevelClicked;
	}

	private void OnDestroy()
	{
		LevelItemFrame.onOpenLevelClicked -= OnOpenLevelClicked;
	}


	private void Start()
	{
		ShowLevels();
	}

	private void ResetMenu()
	{
		foreach (Transform child in content)
		{
			Destroy(child.gameObject);
		}
	}

	private void ShowLevels()
	{
		ResetMenu();
		if(levelsContainer.Levels.Count > 0)
		{
			int levelsParentCount = 0;
			Transform newLevelsParent = Instantiate(levelsParent, content).transform;
			levelsParentCount++;
			int levelIndex = 0;
			foreach(var item in levelsContainer.Levels)
			{
				if (levelIndex >= maxLevelsParentCapacity * levelsParentCount)
				{
					newLevelsParent = Instantiate(levelsParent, content).transform;
					levelsParentCount++;
				}
				Instantiate(levelItemFrame, newLevelsParent).Setup(item);
				levelIndex++;
			}
		}
	}

	private void OnOpenLevelClicked(LevelItemSO levelItemSO)
	{
		//if (!canOpenLevelScenes) return;

		canOpenLevelScenes = false;
		SceneManager.LoadScene(levelItemSO.LevelScene.name);
	}

	public void BackBtnClicked()
	{
        SceneManager.LoadScene("NewMenu");
    }

	public void HambergBtnClicked()
	{
		// load what should be loaded 
	}

}

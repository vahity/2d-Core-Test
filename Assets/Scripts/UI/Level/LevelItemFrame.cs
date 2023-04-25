using MH2B.GameModules.ResourceManagment;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItemFrame : MonoBehaviour
{
    [SerializeField] private Color lockedColor;
    [SerializeField] private Image levelIcon;
    [SerializeField] private GameObject openLevel;
    [SerializeField] private RTLTextMeshPro levelIndexText;
    [SerializeField] List<GameObject> stars = new List<GameObject>();

    private LevelItemSO levelItemSO;

	public static System.Action<LevelItemSO> onOpenLevelClicked;

	public void Setup(LevelItemSO levelItemSO)
    {
        this.levelItemSO = levelItemSO;
        levelIcon.sprite = levelItemSO.LevelIcon;
		levelIndexText.text = levelItemSO.LevelIndex.ToString();
        bool unlocked = ResourcesUtilities.GetAvaialbility(levelItemSO.LevelResourceName);
        int levelStars = ResourcesUtilities.GetValue(levelItemSO.LevelResourceName);
        if(!unlocked)
        {
            levelIcon.color = lockedColor;
            openLevel.SetActive(false);
		}
        for(int i = 0; i < stars.Count; i++)
        {
            stars[i].SetActive(i < levelStars);
        }
	}

    public void OpenLevelClicked()
    {
        onOpenLevelClicked?.Invoke(levelItemSO);
	}

}

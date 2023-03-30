using MH2B.GameModules.ResourceManagment;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelItemFrame : MonoBehaviour
{
    [SerializeField] private GameObject locked;
    [SerializeField] private RTLTextMeshPro levelIndexText;
    [SerializeField] List<GameObject> stars = new List<GameObject>();

    private LevelItemSO levelItemSO;

	public static System.Action<LevelItemSO> onOpenLevelClicked;

	public void Setup(LevelItemSO levelItemSO)
    {
        this.levelItemSO = levelItemSO;
        levelIndexText.text = levelItemSO.LevelIndex.ToString();
        bool unlocked = ResourcesUtilities.GetAvaialbility(levelItemSO.LevelResourceName);
        int levelStars = ResourcesUtilities.GetValue(levelItemSO.LevelResourceName);
        locked.SetActive(!unlocked);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject coinMenu;
    [SerializeField] private GameObject packMenu;

    public void BackBtnCLicked()
    {
        SceneManager.LoadScene("NewMenu");
    }

    public void CoinMenuClicked()
    {
		packMenu.SetActive(false);
		coinMenu.SetActive(true);
	}

    public void PackMenuClicked()
    {
		packMenu.SetActive(true);
        coinMenu.SetActive(false);
	}

	public void CharacterMenuClicked()
	{
		// load character scene
	}
}

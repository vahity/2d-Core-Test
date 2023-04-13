using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject coinMenu;
    [SerializeField] private GameObject packMenu;

    public void BackBtnCLicked()
    {

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

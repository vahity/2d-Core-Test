using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Setting;
    public GameObject Store;
    public GameObject Hooshkoo;
    public GameObject skinScreen;
    private void Start()
    {
        Setting.SetActive(false);
        skinScreen.SetActive(false);
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoMiniGame()
    {
        SceneManager.LoadScene("Level 2");
       // Time.timeScale = 1;
    }
    public void GOSetting()
    {
        Setting.SetActive(true);
    }
    public void OutSetting()
    {
        Setting.SetActive(false);

    }
    public void GoStore()
    {
        Setting.SetActive(true);
    }
    public void OutStore()
    {
        Setting.SetActive(false);
    }
    public void OutHooshkoo()
    {
        Hooshkoo.SetActive(false);
    }
    public void goHooshkoo()
    {
        Hooshkoo.SetActive(true);
    }
    public void Gomini2()
    {
        SceneManager.LoadScene("Mini 2");
    }
    public void Gomini3()
    {
        SceneManager.LoadScene("levele11");
    }
    public void GoMiniGame1()
    {
        SceneManager.LoadScene("MiniGame1");
    } 
    public void goskinScreen()
    {
        skinScreen.SetActive(true);
    }
    public void outskinScreen()
    {
        skinScreen.SetActive(false);
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Setting;
    public GameObject canvas;
    public GameObject pausepanel;
    public GameObject Store;
    public GameObject Hooshkoo;
   // public GameObject skinScreen;
    public Button button1;
    public Button button2;
    public Button button3;
    private void Start()
    {
       // Setting.SetActive(false);
      //  skinScreen.SetActive(false);
        pausepanel.SetActive(false);
    }
    public void GoHome()
    {
        SceneManager.LoadScene("NewMenu");
    }
    public void GoMiniGame()
    {
        SceneManager.LoadSceneAsync("Level 2");
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
   // public void goskinScreen()
  //  {
  //      skinScreen.SetActive(true);
  //  }
 //   public void outskinScreen()
 //   {
 //       skinScreen.SetActive(false);
 //   }

    public void DisableButtons()
    {
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;

        Invoke("EnableButtons", 3f);
    }

    private void EnableButtons()
    {
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
    }
    public void gospausepanel()
    {
        pausepanel.SetActive(true);
    }
    public void outpausepanel()
    {
        pausepanel.SetActive(false);
    }
    ////////////////////////////////////////////////////////////////
    public void cameraController()
    {
        StartCoroutine(cameraController1());
        
    }
    IEnumerator cameraController1()
    {
        yield return new WaitForSeconds(2f);
        Camera_Follower.FollowSpeed = 3f;
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadSceneAsync("Level 2");

    }
    public void DisableCanvas()
    {
        canvas.SetActive(false);
    }

}



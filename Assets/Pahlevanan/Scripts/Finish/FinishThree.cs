using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MH2B.GameModules.ResourceManagment;


public class FinishThree : MonoBehaviour
{
    public Player_Life PL;
    private AudioSource finishsound;
    public GameObject WinPanel;
    public TMP_Text barfinish;


    public Player_Life pl;
    private void Start()
    {
        finishsound = GetComponent<AudioSource>();
        barfinish.text = PL.saveHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            pl.win();
            barfinish.text = PL.saveHealth.ToString();
            StartCoroutine(Delay());
            PlayerMovment.Boost = false;
            completeLevel();

        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        WinPanel.SetActive(true);

    }


    private void completeLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        print(currentSceneName);
        if (currentSceneName == "Level 2")  
        {
            if (Player_Life.Health >= 3)
            {
                ResourcesUtilities.SetValue("Level_1", 3);
                ResourcesUtilities.SetAvailibility("Level_1", true);
                ResourcesUtilities.SetAvailibility("Level_2", true);
                print("arrrrrrrrrrrrrrrrrrl");
            }
            else if (Player_Life.Health == 2)
            {
                ResourcesUtilities.SetValue("Level_1", 2);
                ResourcesUtilities.SetAvailibility("Level_2", true);
            }
            else
            {
                ResourcesUtilities.SetValue("Level_1", 1);
                ResourcesUtilities.SetAvailibility("Level_2", true);
            }
        }
        else if (currentSceneName == "Level 2.2")
        {
            if (Player_Life.Health >= 3)
            {
                ResourcesUtilities.SetValue("Level_2", 3);
                ResourcesUtilities.SetAvailibility("Level_3", true);
            }
            else if (Player_Life.Health == 2)
            {
                ResourcesUtilities.SetValue("Level_2", 2);
                ResourcesUtilities.SetAvailibility("Level_3", true);
            }
            else
            {
                ResourcesUtilities.SetValue("Level_2", 1);
                ResourcesUtilities.SetAvailibility("Level_3", true);
            }
        }
        else if (currentSceneName == "Level 3.2")
        {
            if (Player_Life.Health >= 3)
            {
                ResourcesUtilities.SetValue("Level_3", 3);
                ResourcesUtilities.SetAvailibility("Level_4", true);
            }
            else if (Player_Life.Health == 2)
            {
                ResourcesUtilities.SetValue("Level_3", 2);
                ResourcesUtilities.SetAvailibility("Level_4", true);
            }
            else
            {
                ResourcesUtilities.SetValue("Level_3", 1);
                ResourcesUtilities.SetAvailibility("Level_4", true);
            }
        }
        else if (currentSceneName == "Level 4.2")
        {
            if (Player_Life.Health >= 3)
            {
                ResourcesUtilities.SetValue("Level_4", 3);
                ResourcesUtilities.SetAvailibility("Level_5", true);
            }
            else if (Player_Life.Health == 2)
            {
                ResourcesUtilities.SetValue("Level_4", 2);
                ResourcesUtilities.SetAvailibility("Level_5", true);
            }
            else
            {
                ResourcesUtilities.SetValue("Level_1", 1);
                ResourcesUtilities.SetAvailibility("Level_5", true);
            }
        }
        if (currentSceneName == "Level 5.2")
        {
            if (Player_Life.Health >= 3)
            {
                ResourcesUtilities.SetValue("Level_5", 3);
                ResourcesUtilities.SetAvailibility("Level_6", true);
            }
            else if (Player_Life.Health == 2)
            {
                ResourcesUtilities.SetValue("Level_5", 2);
                ResourcesUtilities.SetAvailibility("Level_6", true);
            }
            else
            {
                ResourcesUtilities.SetValue("Level_5", 1);
                ResourcesUtilities.SetAvailibility("Level_6", true);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MH2B.GameModules.ResourceManagment;

public class Finish : MonoBehaviour
{
    public Player_Life PL;
    private AudioSource finishsound;
    public  GameObject WinPanel;
    public  TMP_Text barfinish;


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
            // finishsound.Play();
            //    invoke("completeLevel", 2f);
            pl.win();
            barfinish.text = PL.saveHealth.ToString();
           // WinPanel.SetActive(true);
             StartCoroutine(Delay());
            // WinPanel.SetActive(true);
            PlayerMovment.Boost = false;




            completeLevel();

        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        WinPanel.SetActive(true);
        
        //Time.timeScale = 0;
    }
    private void completeLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Player_Life.Health>=3)
        {
            ResourcesUtilities.SetValue("Level_1", 3);
            ResourcesUtilities.SetAvailibility("Level_2", true);

        }
        else
        {
            ResourcesUtilities.SetValue("Level_1", 2);
            ResourcesUtilities.SetAvailibility("Level_2", true);
        }
            

    }

}

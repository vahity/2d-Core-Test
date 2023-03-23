using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
    public Player_Life PL;
    private AudioSource finishsound;
    public GameObject PausePanel;
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
            // finishsound.Play();
            //    invoke("completeLevel", 2f);
            pl.win();
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        barfinish.text = PL.saveHealth.ToString();
        completeLevel();
        
    }
    private void completeLevel()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}

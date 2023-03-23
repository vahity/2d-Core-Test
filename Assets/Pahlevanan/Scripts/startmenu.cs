using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class startmenu : MonoBehaviour
{

    public float score;
    public TMP_Text T;
    private void Start()
    {
        score = PlayerPrefs.GetFloat("Savecoin");
        T.text = score.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}

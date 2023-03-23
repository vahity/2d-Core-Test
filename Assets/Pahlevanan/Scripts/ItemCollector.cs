using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public  float coins  , score = 0f;
    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource coinAudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinAudioSource.Play();
            Destroy(collision.gameObject);
            coins++;
            score++;
            coinText.text = "" + score;
            
        }

    }
    public  void Savecoin ()
    {
        coins += score;
        PlayerPrefs.SetFloat("Savecoin", coins);
        //float loadedFloat = PlayerPrefs.GetFloat("myFloat");
    }
    public  void Getcoin()
    {
        coins = PlayerPrefs.GetFloat("Savecoin");
    }
}

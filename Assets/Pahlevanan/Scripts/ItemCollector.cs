using MH2B.GameModules.ResourceManagment;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public  int coins  , score = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource coinAudioSource;
    public Transform CoinTarget;
    public float speed=10;
    public Vector2 targetPosition;
     void Update()
    {
        targetPosition = new Vector2(transform.position.x, transform.position.y);
    }

    private IEnumerator MoveCoinToTargetPosition(GameObject coin)
    {
        
        
        while (Vector2.Distance(coin.transform.position, targetPosition) > 0.1f)
        {
            coin.transform.position = Vector2.MoveTowards(coin.transform.position, targetPosition, Time.deltaTime * speed);
            if (Vector2.Distance(coin.transform.position, targetPosition) <= 0.1f)
            {
                break;
            }
            yield return null;
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            coinAudioSource.Play();

            targetPosition = CoinTarget.position;

            StartCoroutine(MoveCoinToTargetPosition(collision.gameObject));

            Destroy(collision.gameObject, 0.3f);
            coins++;
            score++;
            coinText.text = "" + score;


        }

        







    }
    public  void Savecoin ()
    {
       
      
        coins += score;
        ResourcesUtilities.SetValue("Coin", score);

        PlayerPrefs.SetInt("Savecoin", coins);
        //float loadedFloat = PlayerPrefs.GetFloat("myFloat");
    }
    public  void Getcoin()
    {
        coins = PlayerPrefs.GetInt("Savecoin");
    }

}

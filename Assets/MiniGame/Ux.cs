using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ux : MonoBehaviour
{
    public Image  TimeHealth;
    public TMP_Text texts;
    public float winTime = 100f;
     public float Timescore = 0f , _wintime;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        winTime-=Time.deltaTime;
        DisplayTime(winTime);
    }

void DisplayTime(float timeToDisplay)
{
  float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  float seconds = Mathf.FloorToInt(timeToDisplay % 60);
  _wintime = seconds;
  texts.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   Timescore += seconds;
}
public void  endscore()
{
  Timescore *=2;
}
}

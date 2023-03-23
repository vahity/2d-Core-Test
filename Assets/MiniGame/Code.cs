using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
     float wintime;
    public Ux ux;
    public GameObject LoseMenu , WinMenu ;
  public int _randompos = 0;
   public TMP_Text score;
    public GameObject [] Pic = new GameObject [3];
    private GameObject _Pick;
     public Color [] btn_color = new Color[4];
    public int Answer , Score;
    void Start()
    {
       
        int Select = Random.Range(0,Pic.Length);
       _Pick = Instantiate(Pic[Select],transform.position,transform.rotation);
        LoseMenu.SetActive(false);
        WinMenu.SetActive(false);
    }

     
    void Update()
    {
        wintime = ux.winTime;
            if(Score<20 && wintime<=0)
            {
                LoseMenu.SetActive(true);
            }
    }
    public void setcolor ()
    {

    }
        
    public  RectTransform [] btn    = new RectTransform [4];
    public  Vector2       [] trans  = new Vector2       [4];
        public  void btnpos ()
    {
        _randompos = Random.Range(0,4);
        switch(_randompos)
        {
         case 0: btn[0].anchoredPosition=trans[3];
                 btn[1].anchoredPosition=trans[2];
                 btn[2].anchoredPosition=trans[1];
                 btn[3].anchoredPosition=trans[0];
         break;
        case 1:  btn[0].anchoredPosition=trans[0];
                 btn[1].anchoredPosition=trans[3];
                 btn[2].anchoredPosition=trans[2];
                 btn[3].anchoredPosition=trans[1];
         break;
        case 2:  btn[0].anchoredPosition=trans[1];
                 btn[1].anchoredPosition=trans[0];
                 btn[2].anchoredPosition=trans[3];
                 btn[3].anchoredPosition=trans[2];
         break;
        case 3:  btn[0].anchoredPosition=trans[0];
                 btn[1].anchoredPosition=trans[1];
                 btn[2].anchoredPosition=trans[2];
                 btn[3].anchoredPosition=trans[3];
         break;
        }  
    }
    public void ChosePic (int Answers)
    {
         Destroy(_Pick);
         //true choise
         if(Answers>0)
         {
            btnpos ();
        int Select = Random.Range(0,Pic.Length);
       _Pick = Instantiate(Pic[Select],transform.position,transform.rotation);
            Score++;
            score.text = Score.ToString();
            
            if(Score>=20)
            {
                WinMenu.SetActive(true);
            }

            return;
         }
        //wrong choise
         else if(Answers<0)
         {
          
            LoseMenu.SetActive(true);
            score.text = Score.ToString();
            return;
         }
         
    }

}
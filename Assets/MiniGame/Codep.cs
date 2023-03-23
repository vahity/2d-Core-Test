using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Codep : MonoBehaviour
{
   int _randompos = 0;
   public TMP_Text score;
    public GameObject [] Pic = new GameObject [3];
    private GameObject _Pick;
     public Color [] btn_color = new Color[4];
    public int Answer , Score;
    void Start()
    {
        int Select = Random.Range(0,Pic.Length);
       _Pick = Instantiate(Pic[Select],transform.position,transform.rotation);
      //  for(int i=0 ; i<=Pic.Length;i++ )
      //  {
      //   Pic[i].SetActive(false);
      //  }
        
    }

     
    void Update()
    {
        
    }
    public void setcolor ()
    {
      
    }
    public  RectTransform [] btn    = new RectTransform [4];
    public  Vector2       [] trans  = new Vector2       [4];
        public  void btnpos ()
    {
        
        
        if(btn[3].anchoredPosition != btn[_randompos].anchoredPosition)
        {
         _randompos = Random.Range(0,4);
        Vector2 Temp = btn[3].anchoredPosition;
        btn[3].anchoredPosition = trans[_randompos];
        if(btn[3].anchoredPosition == btn[_randompos].anchoredPosition)
        {
        btn[_randompos].anchoredPosition = Temp;
        }
        else
        {
           btn[_randompos].anchoredPosition = btn[_randompos].anchoredPosition;
        }
       
        
        
        }
        else
        {
         _randompos = Random.Range(0,4);
         return;
        }
       

    }
    public void ChosePic (int Answers)
    {

         Destroy(_Pick);
         if(Answers>0)
         {
            btnpos ();
        int Select = Random.Range(0,Pic.Length);
       _Pick = Instantiate(Pic[Select],transform.position,transform.rotation);
            Score++;
            score.text = Score.ToString();
            return;
         }
        
         else if(Answers<0)
         {
          
            Score--;
            score.text = Score.ToString();
            return;
         }
         
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mini4Controller : ScriptableObject
{
    public Image[] aks;
    public int Health = 0;
    public Text[] Gozine; 

    // public string name = "mini 41";
  //  public Sprite[] image;
    //  public Text[] text;
   

    public void Next()
    {
        SceneManager.LoadScene("");
    }
    public void True()
    {
        Next();
    }
    public void False()
    {
        Health++;
        if (Health==2)
        {
           // Next();
            Health = 0;
        }
    }
}

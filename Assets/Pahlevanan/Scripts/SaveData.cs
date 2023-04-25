using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int  SkinNumber=0;
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void UseSkin(int  SkinNumber)
    {
        if (SkinNumber == 0)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit0");
            PlayerPrefs.SetInt("Side" , SkinNumber);
        }
        else if(SkinNumber == 1)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit1");
            PlayerPrefs.SetInt("Side", SkinNumber);
        }
        else if (SkinNumber == 2)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit2");
            PlayerPrefs.SetInt("Side", SkinNumber);
        }
        else if (SkinNumber == 3)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit3");
            PlayerPrefs.SetInt("Side", SkinNumber);
        }
        else if (SkinNumber == 4)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit4");
            PlayerPrefs.SetInt("Side", SkinNumber);
        }
        else if (SkinNumber == 5)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit5");
            PlayerPrefs.SetInt("Side", SkinNumber);
        }
        else if (SkinNumber == 6)
        {
            PlayerPrefs.SetString("CurrentSkin", "outfit6");
            PlayerPrefs.SetInt("Side", SkinNumber);
        }
       

    }
}

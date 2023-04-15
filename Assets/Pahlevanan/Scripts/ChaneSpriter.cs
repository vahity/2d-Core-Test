using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaneSpriter : MonoBehaviour
{
    public Sprite[] bodySprites;
    public Sprite[] outfit0Sprites;
    public Sprite[] outfit1Sprites;
    public Sprite[] outfit2Sprites;
    public Sprite[] outfit3Sprites;
    public Sprite[] outfit4Sprites;
    public Sprite[] outfit5Sprites;
    public Sprite[] outfit6Sprites;
    private string currentOutfit ;
    public Image SideChar;
    public int SideNumber = 0;

    public Sprite[] images;
    void Awake()
    {
        currentOutfit = PlayerPrefs.GetString("CurrentSkin");

        SetOutfit(currentOutfit);
    }

    void Start()
    {
        
      
    }

    void SetOutfit(string outfit)
    {
        currentOutfit = outfit;
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.sprite == bodySprites[0] )
            {
               

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[0];
                    Debug.Log("1");
             
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[0];
               
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[0];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[0];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[0];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[0];

                }

            }
            else if (renderer.sprite == bodySprites[1])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[1];
                    Debug.Log("2");
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[1];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[1];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[1];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[1];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[1];

                }
            }
            else if (renderer.sprite == bodySprites[2])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[2];
                    Debug.Log("3");
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[2];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[2];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[2];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[2];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[2];

                }
            }
           else if (renderer.sprite == bodySprites[3])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[3];
                    Debug.Log("4");
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[3];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[3];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[3];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[3];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[3];

                }
            }
            else if (renderer.sprite == bodySprites[4])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[4];
                    Debug.Log("5");
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[4];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[4];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[4];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[4];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[4];

                }
            }
            
            else if (renderer.sprite == bodySprites[5])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[5];
                        Debug.Log("6");
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[5];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[5];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[5];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[5];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[5];

                }
            }
            
            else if (renderer.sprite == bodySprites[6])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[6];
                      
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[6];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[6];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[6];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[6];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[6];

                }
            }
            
            else if (renderer.sprite == bodySprites[7])
            {

                if (outfit == "outfit1")
                {
                    Debug.Log("8");
                    renderer.sprite = outfit1Sprites[7];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[7];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[7];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[7];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[7];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[7];

                }
            }
            else if (renderer.sprite == bodySprites[8])
            {

                if (outfit == "outfit1")
                {
                    Debug.Log("9");
                    renderer.sprite = outfit1Sprites[8];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[8];
                }
                else if (outfit == "outfit3")
                {
                    renderer.sprite = outfit3Sprites[8];

                }
                else if (outfit == "outfit4")
                {
                    renderer.sprite = outfit4Sprites[8];

                }
                else if (outfit == "outfit5")
                {
                    renderer.sprite = outfit5Sprites[8];

                }
                else if (outfit == "outfit6")
                {
                    renderer.sprite = outfit6Sprites[8];

                }
            }
            /*
            else if (renderer.sprite == bodySprites[9])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[9];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[9];
                }
            } 
            */
        }
    }


     void Update()
    {

        /*     if (Input.GetKeyDown(KeyCode.Alpha1))
             {
                SetOutfit("outfit1");
                Debug.Log(KeyCode.Alpha1);
             }
             else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetOutfit("outfit2");
                Debug.Log(KeyCode.Alpha2);
            }
       */
       SideNumber = PlayerPrefs.GetInt("Side");
        if (SideNumber == 1)
        {
            Debug.Log("Side1");
            SideChar.sprite = images[1];
        }
        else if (SideNumber == 2)
        {
            SideChar.sprite = images[2];
        }
        else if (SideNumber == 3)
        {
            SideChar.sprite = images[3];
        }
        else if (SideNumber == 4)
        {
            SideChar.sprite = images[4];
        }
        else if (SideNumber == 5)
        {
            SideChar.sprite = images[5];
        }
        else if (SideNumber == 6)
        {
            SideChar.sprite = images[6];
        }


    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
  
  


}

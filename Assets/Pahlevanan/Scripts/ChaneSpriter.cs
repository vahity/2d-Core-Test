using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaneSpriter : MonoBehaviour
{
    public Sprite[] bodySprites;
    public Sprite[] outfit1Sprites;
    public Sprite[] outfit2Sprites;
    private string currentOutfit ;

    void Start()
    {
        
        currentOutfit = PlayerPrefs.GetString("CurrentSkin");

        SetOutfit(currentOutfit);
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
             
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[0];
               
                }
            }
            else if (renderer.sprite == bodySprites[1])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[1];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[1];
                }
            }
            else if (renderer.sprite == bodySprites[2])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[2];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[2];
                }
            }
            else if (renderer.sprite == bodySprites[3])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[3];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[3];
                }
            }
            else if (renderer.sprite == bodySprites[4])
            {

                if (outfit == "outfit1")
                {
                    renderer.sprite = outfit1Sprites[4];
                }
                else if (outfit == "outfit2")
                {
                    renderer.sprite = outfit2Sprites[4];
                }
            }

        }
    }

   
   // {
       
     //   if (Input.GetKeyDown(KeyCode.Alpha1))
      //  {
    //        SetOutfit("outfit1");
     //       Debug.Log(KeyCode.Alpha1);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha2))
     //   {
    //        SetOutfit("outfit2");
     //       Debug.Log(KeyCode.Alpha2);
     //   }

   // }
}

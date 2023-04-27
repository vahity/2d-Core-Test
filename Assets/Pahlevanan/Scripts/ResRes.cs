using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MH2B.GameModules.ResourceManagment;
using TMPro.EditorUtilities;
using TMPro;

public class ResRes : MonoBehaviour
{
    
    public TMP_Text CoinSaveU;
    // Start is called before the first frame update
    void Start()
    {
       // ResourcesUtilities.GetValue("Coin");
     //   ResourcesUtilities.GetValue("Coin").ToString();

       
    }

    // Update is called once per frame
    void Update()
    {
        CoinSaveU.text = ResourcesUtilities.GetValue("Coin").ToString();
    }
    /*
    public void One2Two()
    {
        if(0<ResourcesUtilities.GetValue("Level_1"))
        {
            ResourcesUtilities.SetAvailibility("Level_2", true);
        }
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddButtens : MonoBehaviour
{
    [SerializeField]
    private Transform puzzelField;
    [SerializeField]
    private GameObject btn;
     void Awake()
    {
        for(int i=0; i<8; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzelField, false); 
        }
    }

}
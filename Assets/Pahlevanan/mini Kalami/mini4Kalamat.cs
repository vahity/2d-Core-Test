using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "newcard", menuName = "card")]
public class mini4Kalamat : ScriptableObject
{
    public Sprite[] aks;
    public int Health = 0;
    public Text[] Gozine = new Text[4];
}
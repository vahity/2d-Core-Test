using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemsContainer" , menuName = "Shop/Container")]
public class ShopItemsContainer : ScriptableObject
{
    public List<ShopItemSO> ShopItemSOs = new List<ShopItemSO>();
}

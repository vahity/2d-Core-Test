using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.ShopManagement
{
    [CreateAssetMenu(fileName = "ShopItems", menuName = "Shop/Item")]
    public class ShopItemSO : ScriptableObject
    {
        public ShopItemModel ShopItemModel;
    }

}



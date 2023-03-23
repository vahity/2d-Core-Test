using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemController
{
    private ShopItemModel shopItemModel;
    private ShopItemView shopItemView;

    public ShopItemController(ShopItemView shopItemView , ShopItemModel shopItemModel) 
    {
        this.shopItemModel = shopItemModel;
        this.shopItemView = shopItemView;
        shopItemView.Setup(shopItemModel);
        shopItemView.onShopBuyClicked += OnBuyClicked;
	}

    private void OnBuyClicked()
    {
        Debug.Log($"Shop Item Clicked {shopItemModel.Name}");
    }
}

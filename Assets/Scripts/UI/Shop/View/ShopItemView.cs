using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.ShopManagement
{
	public class ShopItemView : MonoBehaviour
	{
		private ShopItemModel shopItemModel;


		public event Action onShopBuyClicked;

		public void Setup(ShopItemModel shopItemModel)
		{
			this.shopItemModel = shopItemModel;
		}

		public void BuyClicked()
		{
			onShopBuyClicked?.Invoke();
		}
	}
}



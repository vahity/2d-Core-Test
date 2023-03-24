using System;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.ShopManagement
{
	[MarkedOnlineMarketClass("TargetStore")]
	public class BazaarMarket : IOnlineMarket
	{
		private const string RSA = "";

		public static string TargetStore => PublishSettings.PublishStore.Bazaar.ToString();

		public void InitMarket()
		{
			BazaarManager.Instance.Init(RSA);
		}

		public void Purchase(string productID, long price, Action<bool, string> onConsumed = null)
		{
			BazaarManager.Instance.Purchase(productID, price, onConsumed);
		}

		public void UnConsumedConsume(string productID, Action<bool, string> onFinished = null)
		{
			BazaarManager.Instance.UnConsumedConsume(productID, onFinished);
		}

		public void LoadPurchaseQuery(string[] skus, Action onComplete)
		{
			BazaarManager.Instance.LoadPurchaseQuery(skus, onComplete);
		}

		public List<UnconsumedPurchases> GetUnconsumedPurchases()
		{
			return BazaarManager.Instance.UnconsomedPurchases;
		}

		public void LoadProductsQuery(string[] skus, Action onComplete)
		{
			BazaarManager.Instance.LoadProductsQuery(skus, onComplete);
		}

		public List<StoreSKUDetails> GetStoreSKUDetails()
		{
			return BazaarManager.Instance.StoreSKUDetails;
		}

		public void RemoveFormUncomsomedPurchases(string productID)
		{
			BazaarManager.Instance.RemoveFormUncomsomedPurchases(productID);
		}

		public void Disconnect()
		{
			throw new NotImplementedException();
		}

	}

}



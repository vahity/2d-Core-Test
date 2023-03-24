using System;
using System.Collections.Generic;

namespace MH2B.ShopManagement
{
	[System.AttributeUsage(System.AttributeTargets.Class)]
	public class MarkedOnlineMarketClassAttribute : System.Attribute
	{
		public string TargetAttribute;
		public MarkedOnlineMarketClassAttribute(string targetAttribute)
		{
			TargetAttribute = targetAttribute;
		}
	}


	public interface IOnlineMarket
	{
		void InitMarket();
		void Disconnect();
		void Purchase(string productID, long price, Action<bool, string> onConsumed = null);
		void UnConsumedConsume(string productID, Action<bool, string> onFinished = null);
		void LoadPurchaseQuery(string[] skus, Action onComplete = null);
		void LoadProductsQuery(string[] skus, Action onComplete = null);
		List<UnconsumedPurchases> GetUnconsumedPurchases();
		List<StoreSKUDetails> GetStoreSKUDetails();
		void RemoveFormUncomsomedPurchases(string sku);
	}

}


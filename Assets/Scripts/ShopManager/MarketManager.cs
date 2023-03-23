using MyketPlugin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MarketManager<T> : PersistentSingleton<T> where T : PersistentSingleton<T>
{
	[SerializeField] private PublishSettings.PublishStore targetStore;

	public List<UnconsumedPurchases> UnconsomedPurchases = new List<UnconsumedPurchases>();
	public List<StoreSKUDetails> StoreSKUDetails = new List<StoreSKUDetails>();

	protected override void Awake()
	{
		if (PublishSettings.PUBLISH_STORE != targetStore)
		{
			Destroy(this);
			return;
		}
		base.Awake();
	}

	public void RemoveFormUncomsomedPurchases(string sku)
	{
		UnconsumedPurchases found = UnconsomedPurchases.Find(x => x.ProductID.Equals(sku));
		if (found != null)
		{
			UnconsomedPurchases.Remove(found);
		}
	}
}

public class UnconsumedPurchases
{
	public string ProductID;
	public string PurchaseToken;

	public UnconsumedPurchases(string productID , string purchaseToken)
	{
		ProductID = productID;
		PurchaseToken = purchaseToken;
	}
}

public class StoreSKUDetails
{
	public string ProductID;
	public string ProductPrice;

	public StoreSKUDetails(string productID, string productPrice)
	{
		ProductID = productID;
		ProductPrice = productPrice;
	}
}

public class PublishSettings
{
	public enum PublishStore
	{
		None,
		Bazaar,
		Myket,
		GooglePlay
	}

	public static PublishStore PUBLISH_STORE = PublishStore.Bazaar;
}

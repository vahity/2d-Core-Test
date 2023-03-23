using System;
using System.Collections.Generic;
using UnityEngine;

[MarkedOnlineMarketClass("TargetStore")]
public class MyketMarket : IOnlineMarket
{
	private const string RSA = "";

	public static string TargetStore => PublishSettings.PublishStore.Myket.ToString();

	public void InitMarket()
	{
		MyketManager.Instance.Init(RSA);
	}

	public void Purchase(string productID, long price, Action<bool, string> onConsumed = null)
	{
		MyketManager.Instance.BuyProduct(productID, onConsumed);
	}

	public void UnConsumedConsume(string productID, Action<bool, string> onFinished = null)
	{
		MyketManager.Instance.UnConsumedConsume(productID, onFinished);
	}

	public void LoadPurchaseQuery(string[] skus , Action onComplete)
	{
		MyketManager.Instance.LoadPurchaseQuery(skus , onComplete);
	}

	public List<UnconsumedPurchases> GetUnconsumedPurchases()
	{
		return MyketManager.Instance.UnconsomedPurchases;
	}

	public void LoadProductsQuery(string[] skus, Action onComplete)
	{
		MyketManager.Instance.LoadProductsQuery(skus , onComplete);
	}

	public List<StoreSKUDetails> GetStoreSKUDetails()
	{
		return MyketManager.Instance.StoreSKUDetails;
	}

	public void RemoveFormUncomsomedPurchases(string productID)
	{
		MyketManager.Instance.RemoveFormUncomsomedPurchases(productID);
	}

	public void Disconnect()
	{
		throw new NotImplementedException();
	}

}

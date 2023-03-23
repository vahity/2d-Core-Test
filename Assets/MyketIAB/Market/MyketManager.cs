using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MyketPlugin;
using UnityEngine;

public class MyketManager : MarketManager<MyketManager>
{
	private Action onQueryPurchaseResponse;
	private Action onQueryProductsResponse;

	private Action<bool, string> onBuyProcessFinished;

	void OnEnable()
	{
		// Listen to all events for illustration purposes
		IABEventManager.billingSupportedEvent += billingSupportedEvent;
		IABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		IABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		IABEventManager.querySkuDetailsSucceededEvent += querySkuDetailsSucceededEvent;
		IABEventManager.querySkuDetailsFailedEvent += querySkuDetailsFailedEvent;
		IABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
		IABEventManager.purchaseFailedEvent += purchaseFailedEvent;
		IABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		IABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
	}


	void OnDisable()
	{
		// Remove all event handlers
		IABEventManager.billingSupportedEvent -= billingSupportedEvent;
		IABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		IABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		IABEventManager.querySkuDetailsSucceededEvent -= querySkuDetailsSucceededEvent;
		IABEventManager.querySkuDetailsFailedEvent -= querySkuDetailsFailedEvent;
		IABEventManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		IABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
		IABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		IABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
	}

	public void Init(string rsa)
	{
		MyketIAB.init(rsa);
	}

	public void BuyProduct(string sku , Action<bool , string> onFinished)
	{
		onBuyProcessFinished = onFinished;
		MyketIAB.purchaseProduct(sku);
	}

	public void ConsumeProduct(string sku)
	{
		MyketIAB.consumeProduct(sku);
	}

	public void UnConsumedConsume(string sku, Action<bool, string> onFinished)
	{
		onBuyProcessFinished = onFinished;
		MyketIAB.purchaseProduct(sku);
	}

	public void LoadPurchaseQuery(string[] skus, Action onComplete)
	{
		onQueryPurchaseResponse = onComplete;
		MyketIAB.queryInventory(skus);
	}

	public void LoadProductsQuery(string[] skus, Action onComplete)
	{
		onQueryProductsResponse = onComplete;
		MyketIAB.querySkuDetails(skus);
	}

	void billingSupportedEvent()
	{
		MyDebug("billingSupportedEvent");
	}


	void queryInventorySucceededEvent(List<MyketPurchase> purchases, List<MyketSkuInfo> skus)
	{
		UnconsomedPurchases.Clear();
		MyDebug("Query Inventory Succeded ..." + purchases.Count + " " + skus.Count);
		foreach (var item in purchases)
		{
			if (UnconsomedPurchases.Find(x => x.ProductID.Equals(item.ProductId)) == null)
			{
				MyDebug($"{item.ProductId} : {item.PurchaseState}");
				UnconsomedPurchases.Add(new UnconsumedPurchases(item.ProductId, item.PurchaseToken));
			}
		}
		onQueryPurchaseResponse?.Invoke();
	}


	private void queryInventoryFailedEvent(string obj)
	{
		MyDebug("Query Inventory Failed ..." + obj);
		onQueryPurchaseResponse?.Invoke();
	}

	private void querySkuDetailsSucceededEvent(List<MyketSkuInfo> skus)
	{
		StoreSKUDetails.Clear();
		MyDebug("Query SKU Succeded ..." + skus.Count);
		foreach (var item in skus)
		{
			if (StoreSKUDetails.Find(x => x.ProductID.Equals(item.ProductId)) == null)
			{
				try
				{
					string resultPriceString = Regex.Match(item.Price, @"\d+.+\d").Value;
					MyDebug($"{item.ProductId} : {resultPriceString}");
					StoreSKUDetails.Add(new StoreSKUDetails(item.ProductId, resultPriceString));
				}
				catch(Exception ex)
				{

				}
			}
		}
		onQueryProductsResponse?.Invoke();
	}

	private void querySkuDetailsFailedEvent(string obj)
	{
		MyDebug("Query SKU Failed ..." + obj);
		onQueryProductsResponse?.Invoke();
	}


	void purchaseSucceededEvent(MyketPurchase purchase)
	{
		MyDebug("purchaseSucceededEvent: " + purchase);
		ConsumeProduct(purchase.ProductId);
	}

	void purchaseFailedEvent(string error)
	{
		MyDebug("purchaseFailedEvent: " + error);
		OnBuyProcessFinished(false, error);
	}

	void consumePurchaseSucceededEvent(MyketPurchase purchase)
	{
		MyDebug("consumePurchaseSucceededEvent: " + purchase);
		OnBuyProcessFinished(true);
	}

	void consumePurchaseFailedEvent(string error)
	{
		MyDebug("consumePurchaseFailedEvent: " + error);
		OnBuyProcessFinished(false, error);
	}

	private void MyDebug(string debug)
	{
		Debug.Log(debug);
		return;
	}

	private void OnBuyProcessFinished(bool result, string message = default)
	{
		onBuyProcessFinished?.Invoke(result, message);
		onBuyProcessFinished = null;
	}

}



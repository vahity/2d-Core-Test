using Bazaar.Poolakey.Data;
using Bazaar.Poolakey;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyketPlugin;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

public class BazaarManager : MarketManager<BazaarManager>
{
	private Payment m_Payment;
	private Action<bool, string> onBuyProcessFinished;

	public void Init(string rsa)
	{
		MyDebug("Started Initializing");
		SecurityCheck securityCheck = SecurityCheck.Enable(rsa);
		PaymentConfiguration paymentConfiguration = new PaymentConfiguration(securityCheck);
		m_Payment = new Payment(paymentConfiguration);

		var connect = m_Payment.Connect((result) => { MyDebug("Initializing ... :" + result.message); });
	}



	public void Purchase(string productID, long price, Action<bool, string> onConsumed = null)
	{
		price *= 10;
		onBuyProcessFinished = onConsumed;
		if (m_Payment == null)
		{
			MyDebug("Purchase Failed Event!");
			OnBuyProcessFinished(false, "Payment was not inited");
			return;
		}

		var purchace = m_Payment.Purchase(productID, SKUDetails.Type.inApp,
			(onStart) =>
			{
				MyDebug("Purchase Started...");
			},
			(onComplete) =>
			{
				MyDebug("Purchase Succeeded Event: " + productID);
				if (onComplete.status == Bazaar.Data.Status.Success)
				{
					Consume(onComplete.data.purchaseToken);
				}
				else
				{
					MyDebug("Purchase Failed Event: ");
					OnBuyProcessFinished(false, "Purchase status was not successfull");
				}
			},
				"", null
			);
	}

	public void Consume(string purchaseToken)
	{
		if (m_Payment == null)
		{
			MyDebug("Consume Failed Event!");
			OnBuyProcessFinished(false, "Payment was not inited");
			return;
		}

		var consume = m_Payment.Consume(purchaseToken,
			(onComplete) =>
			{
				if (onComplete.status == Bazaar.Data.Status.Success)
				{
					MyDebug("Consume Succeeded Event: " + purchaseToken);
					OnBuyProcessFinished(true, "Succed");
				}
				else
				{
					MyDebug("Consume Purchase Failed Event: ");
					OnBuyProcessFinished(false, "Consume status was not successfull");
				}

			});
	}

	public void UnConsumedConsume(string sku, Action<bool, string> onFinished)
	{
		onBuyProcessFinished = onFinished;
		Consume(UnconsomedPurchases.Find(x => x.ProductID == sku).PurchaseToken);
	}

	public async void LoadPurchaseQuery(string[] skus, Action onComplete)
	{
		if (m_Payment == null)
		{
			return;
		}

		UnconsomedPurchases.Clear();
		var inventory = await m_Payment.GetPurchases(SKUDetails.Type.all);
		if (inventory != null && inventory.data != null && inventory.status == Bazaar.Data.Status.Success)
		{
			foreach (var purchaseInfo in inventory.data)
			{
				if (UnconsomedPurchases.Find(x => x.ProductID.Equals(purchaseInfo.productId)) == null)
				{
					MyDebug("Purchased item : " + purchaseInfo.ToString() + " has been consumed : " + (purchaseInfo.purchaseState == PurchaseInfo.State.Consumed));
					UnconsomedPurchases.Add(new UnconsumedPurchases(purchaseInfo.productId, purchaseInfo.purchaseToken));
				}
			}
		}
		onComplete?.Invoke();
	}

	public async void LoadProductsQuery(string[] skus, Action onComplete)
	{
		if (m_Payment == null)
		{
			return;
		}

		StoreSKUDetails.Clear();
		foreach(var sku in skus)
		{
			var inventory = await m_Payment.GetSkuDetails(sku, SKUDetails.Type.all);
			if(inventory != null && inventory.data != null)
			{
				foreach (var skuInfo in inventory.data)
				{
					if (StoreSKUDetails.Find(x => x.ProductID.Equals(skuInfo.sku)) == null)
					{
						try
						{
							string resultPriceString = Regex.Match(skuInfo.price, @"\d+.+\d").Value;
							resultPriceString = resultPriceString.Remove(resultPriceString.Length - 1, 1);
							StringBuilder stringBuilder = new StringBuilder();
							for (int i = 0; i < resultPriceString.Length; i++)
							{
								if (resultPriceString[i] == ',' || resultPriceString[i] == '.')
								{
									continue;
								}
								if (i + 1 < resultPriceString.Length)
								{
									if (resultPriceString[i + 1] == ',' || resultPriceString[i + 1] == '.')
									{
										stringBuilder.Append(resultPriceString[i + 1]);
									}
								}
								stringBuilder.Append(resultPriceString[i]);
							}
							MyDebug("SKU item : " + skuInfo.sku + " : " + stringBuilder.ToString());
							StoreSKUDetails.Add(new StoreSKUDetails(skuInfo.sku, stringBuilder.ToString()));
						}
						catch (Exception ex)
						{

						}
					}
				}
			}
			
		}
		onComplete?.Invoke();
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

using MH2B.GameModules.ResourceManagment;
using MH2B.Rewarding;
using MH2B.ShopManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemFrame : MonoBehaviour
{
    [SerializeField] private string sku;
    [SerializeField] private int price;
    [SerializeField] private string priceResource;
    [SerializeField] private List<TransactionStep> steps = new List<TransactionStep>();

    public void BuyClicked()
    {
        if (string.IsNullOrEmpty(priceResource))
        {
			ShopManager.Instance.marketManager.Purchase(sku, price, OnConsumePurchase);
		}
		else
        {
            int resourceValue = ResourcesUtilities.GetValue(priceResource);

			if (resourceValue >= price)
            {
                ResourcesUtilities.SetValue(priceResource, resourceValue - price);
                OnConsumePurchase(true , "succed");
			}
            else
            {
				OnConsumePurchase(false, "Not enough resource to buy");
			}
        }
    }

    private void OnConsumePurchase(bool result , string message)
    {
        RewardingManager.Instance.Reward(steps);
    }

}

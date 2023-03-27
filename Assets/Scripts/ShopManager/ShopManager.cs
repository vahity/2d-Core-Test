//using Bazaar.Poolakey.Data;
using MyketPlugin;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace MH2B.ShopManagement
{
	public class ShopManager : PersistentSingleton<ShopManager>
	{

		public static ShopManager Manager;

		[SerializeField] private GameObject overlayCanvas;
		[SerializeField] private ShopItemsContainer ShopItemContainer;

		public IOnlineMarket marketManager;

		private bool isWaitingForPrevForceConsume;
		private List<Action> waitForPrevForceConsume = new List<Action>();

		public static Action<string> onShopItemClicked;
		public static Action<string, string, double> onShopSucced;
		public static Action<string, string> onShopFailed;


		private void Start()
		{
			HandleAndroidBuild_Start();
		}

		private IOnlineMarket GetOnlineMarket()
		{
			var currentAssembly = Assembly.GetCallingAssembly();
			foreach (var assembly in currentAssembly.GetTypes())
			{
				if (!assembly.IsClass)
				{
					continue;
				}

				var classAttribute = assembly.GetCustomAttribute<MarkedOnlineMarketClassAttribute>();
				if (classAttribute != null)
				{
					var foundProperty = assembly.GetProperty(classAttribute.TargetAttribute);
					if (foundProperty != null)
					{
						if ((foundProperty.GetValue(null) as string).Equals(PublishSettings.PUBLISH_STORE.ToString()))
						{
							IOnlineMarket instance = (IOnlineMarket)Activator.CreateInstance(assembly);
							return instance;
						}
					}
				}
			}
			return null;
		}

		void HandleAndroidBuild_Start()
		{
			IOnlineMarket market = GetOnlineMarket();
			marketManager = market;
			marketManager.InitMarket();
			LoadQueries();
		}

		private void LoadQueries()
		{
			List<string> skusList = new List<string>();
			foreach (var item in ShopItemContainer.ShopItemSOs)
			{
				if (!skusList.Contains(item.ShopItemModel.SKU))
				{
					skusList.Add(item.ShopItemModel.SKU);
				}
			}
			string[] skusArray = skusList.ToArray();
			marketManager.LoadProductsQuery(skusArray, () => marketManager.LoadPurchaseQuery(skusArray));
		}

		public void ChangeOverlayCanvasState(bool state)
		{
			overlayCanvas.SetActive(state);
		}


		public void ForceConsume(string productID, Action<bool, string> onConsumed = null)
		{
			overlayCanvas.SetActive(true);
			if (isWaitingForPrevForceConsume)
			{
				if (!waitForPrevForceConsume.Contains(() => ForceConsume(productID, onConsumed))) waitForPrevForceConsume.Add(() => ForceConsume(productID, onConsumed));
				return;
			}
			isWaitingForPrevForceConsume = true;
			marketManager.UnConsumedConsume(productID, onConsumed);
		}


		public void ForceConsumeProcessFinished()
		{
			isWaitingForPrevForceConsume = false;

			if (waitForPrevForceConsume.Count > 0)
			{
				waitForPrevForceConsume[0]?.Invoke();
				waitForPrevForceConsume.RemoveAt(0);
			}
			else
			{
				overlayCanvas.SetActive(false);
			}
		}

		public void OnPurchaseComplete(string productID, double cost)
		{
			onShopSucced?.Invoke(productID, ShopedStore(), cost);
		}
		public void OnPurchaseFail(string productID, string purchaseError)
		{
			onShopFailed?.Invoke(productID, ShopedStore());
		}

		private string ShopedStore()
		{
			return PublishSettings.PUBLISH_STORE.ToString();
		}


	}

}



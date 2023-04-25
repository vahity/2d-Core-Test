using MH2B.Utilities;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public class ResourceManager : PersistentSingleton<ResourceManager>
	{

		public ResourcesContainer ResourcesContainer;

		public List<ResourceControllerBase> resourceControllerBases = new List<ResourceControllerBase>();

		protected override void Awake()
		{
			base.Awake();
			Init();
		}

		private void OnApplicationQuit()
		{
#if UNITY_EDITOR
			SaveAllResources();
#endif
		}

		private void OnApplicationPause(bool pause)
		{
			if (pause)
			{
#if UNITY_EDITOR
				return;
#endif
				SaveAllResources();
			}
		}

		public void Init()
		{
			LoadAllResources();
		}

		public T GetResourceByName<T>(string resourceName) where T : class
		{
			var resultResource = resourceControllerBases.Find(x => x.GetName().Equals(resourceName));
			if (resultResource == null)
				return default;
			else
			{
				if (resultResource is T)
				{
					return (resultResource as T);
				}
				else
				{
					return default;
				}
			}

		}

		public void LoadAllResources()
		{
			foreach (var item in ResourcesContainer.CurrencyResources)
			{
				LoadResource(item.CurrencyResource);
			}
		}

		public ResourceControllerBase LoadResource(ResourceBase resourceBase)
		{
			return AddToResourceControllers(resourceBase.LoadResource());
		}

		public ResourceControllerBase LoadResource(string resourceName)
		{
			ResourceControllerBase resourceControllerBase = resourceControllerBases.Find(x => x.GetName().Equals(resourceName));
			if (resourceControllerBase == null)
			{
				throw new Exception($"Error saving resource {resourceName} : not exists");
			}
			resourceControllerBase.Resource.LoadResource();
			return AddToResourceControllers(resourceControllerBase.Resource);
		}

		private ResourceControllerBase AddToResourceControllers(ResourceBase resourceBase)
		{
			ResourceControllerBase controller = resourceControllerBases.Find(x => x.GetName().Equals(resourceBase.ResourceName));
			if (controller != null)
			{
				controller.UpdateModel(resourceBase);
			}
			else
			{
				ResourceControllerBase newItemController = resourceBase.AddContoller();
				resourceControllerBases.Add(newItemController);
			}
			return controller;
		}

		public void SaveAllResources()
		{
			foreach (var contoller in resourceControllerBases)
			{
				SaveResource(contoller);
			}
		}

		private ResourceControllerBase SaveResource(string resourceName)
		{
			ResourceControllerBase resourceControllerBase = resourceControllerBases.Find(x => x.GetName().Equals(resourceName));
			if (resourceControllerBase == null)
			{
				throw new Exception($"Error saving resource {resourceName} : not exists");
			}
			resourceControllerBase.Resource.SaveResource();
			return resourceControllerBase;
		}

		private ResourceControllerBase SaveResource(ResourceControllerBase resourceContollerBase)
		{
			resourceContollerBase.Resource.SaveResource();
			return resourceContollerBase;
		}

		[ContextMenu("GetCoinValue")]
		private void GetCoinValue()
		{
			Debug.LogError(ResourcesUtilities.GetValue("Coin"));
		}

		[ContextMenu("SetCoinValue")]
		private void SetCoinValue()
		{
			ResourcesUtilities.SetValue("Coin", UnityEngine.Random.Range(1, 10));
		}

		[ContextMenu("LoadCoinValue")]
		private void LoadCoinValue()
		{
			ResourcesUtilities.LoadResource("Coin");
		}

		[ContextMenu("SaveCoinValue")]
		private void SaveCoinValue()
		{
			ResourcesUtilities.SaveResource("Coin");
		}

		[ContextMenu("Clear Prefs")]
		private void ClearPrefs()
		{
			PlayrPrefsUtility.ClearPrefs();
		}
	}
}


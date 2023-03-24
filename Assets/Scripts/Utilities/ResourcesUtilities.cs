using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public static class ResourcesUtilities
	{

		public static void LoadResource(string resourceName)
		{
			ResourceControllerBase resource = ResourceManager.Instance?.GetResourceByName<ResourceControllerBase>(resourceName);
			if (resource == default)
			{
				throw new Exception("Resource name : " + resourceName + " may not be valid !!!!");
			}
			resource.Resource.LoadResource();
		}

		public static void SaveResource(string resourceName)
		{
			ResourceControllerBase resource = ResourceManager.Instance?.GetResourceByName<ResourceControllerBase>(resourceName);
			if (resource == default)
			{
				throw new Exception("Resource name : " + resourceName + " may not be valid !!!!");
			}
			resource.Resource.SaveResource();
		}

		public static bool GetAvaialbility(string resourceName)
		{
			ResourceControllerBase resource = ResourceManager.Instance?.GetResourceByName<ResourceControllerBase>(resourceName);
			if (resource == default)
			{
				throw new Exception("Resource name : " + resourceName + " may not be valid !!!!");
			}
			return resource.GetAvailability();
		}

		public static int GetValue(string resourceName)
		{
			ResourceControllerBase resource = ResourceManager.Instance?.GetResourceByName<ResourceControllerBase>(resourceName);
			if (resource == default)
			{
				throw new Exception("Resource name : " + resourceName + " may not be valid !!!!");
			}
			return resource.GetValue();
		}

		public static void Setavailibility(string resourceName, bool availibility)
		{
			ResourceControllerBase resource = ResourceManager.Instance?.GetResourceByName<ResourceControllerBase>(resourceName);
			if (resource == default)
			{
				throw new Exception("Resource name : " + resourceName + " may not be valid !!!!");
			}
			resource.SetAvailability(availibility);
		}

		public static void SetValue(string resourceName, int value)
		{
			ResourceControllerBase resource = ResourceManager.Instance?.GetResourceByName<ResourceControllerBase>(resourceName);
			if (resource == default)
			{
				throw new Exception("Resource name : " + resourceName + " may not be valid !!!!");
			}
			resource.SetValue(value);
		}

	}
}



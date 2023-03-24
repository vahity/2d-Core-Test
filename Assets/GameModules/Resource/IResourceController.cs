using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MH2B.GameModules.ResourceManagment
{
	public interface IResourceController
	{
		public string GetName();
		public bool GetAvailability();
		public int GetValue();
		public void SetAvailability(bool availability);
		public void SetValue(int value);
		public void UpdateModel(ResourceBase resourceBase);
		public void ResourceChanged();
		public void ListenToItemChanges(Action<ResourceBase> listner);
		public void UnListenToItemChanges(Action<ResourceBase> listner);

	}
}


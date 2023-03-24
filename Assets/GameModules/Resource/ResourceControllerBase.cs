using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public abstract class ResourceControllerBase : IResourceController
	{
		public ResourceBase Resource { get; private set; }

		private event Action<ResourceBase> OnItemChanged;

		public ResourceControllerBase(ResourceBase resource)
		{
			Resource = resource;
		}

		public virtual string GetName()
		{
			return Resource.ResourceName;
		}

		public virtual bool GetAvailability()
		{
			return Resource.IsAvailable;
		}

		public virtual int GetValue()
		{
			return Resource.Value;
		}

		public virtual void SetAvailability(bool availability)
		{
			Resource.IsAvailable = availability;
			ResourceChanged();
		}

		public virtual void SetValue(int value)
		{
			Resource.Value = value;
			ResourceChanged();
		}


		public virtual void UpdateModel(ResourceBase resourceBase)
		{
			Resource = resourceBase;
		}

		public virtual void ResourceChanged()
		{
			OnItemChanged?.Invoke(Resource);
		}

		public virtual void ListenToItemChanges(Action<ResourceBase> listner)
		{
			OnItemChanged += listner;
		}
		public virtual void UnListenToItemChanges(Action<ResourceBase> listner)
		{
			OnItemChanged -= listner;
		}
	}
}



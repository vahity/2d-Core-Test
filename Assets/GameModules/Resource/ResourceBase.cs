using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	[Serializable]
	public abstract class ResourceBase : ResourceIDDrawer
	{
		[SerializeField] private string resouurceName;
		public string ResourceName { get { return resouurceName; } set { resouurceName = value; } }

		[SerializeField] private bool isAvailable;
		public bool IsAvailable { get { return isAvailable; } set { isAvailable = value; } }

		[SerializeField] private int value;
		public int Value { get { return value; } set { this.value = value; } }

		public abstract ResourceControllerBase AddContoller();
		public abstract ResourceBase LoadResource();
		public abstract ResourceBase SaveResource();

		public ResourceBase() { }

		public ResourceBase(ResourceBase resourceBase)
		{
			this.ResourceName = resourceBase.ResourceName;
			this.IsAvailable = resourceBase.isAvailable;
			this.Value = resourceBase.value;
		}
	}
}

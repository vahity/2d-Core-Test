using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	[Serializable]
	public class ItemResource : ResourceBase
	{
		public ItemResource() { }

		public ItemResource(ItemResource itemResource) : base(itemResource) 
		{
			InstanceResource = this;
		}

		[JsonIgnore] public ItemResource InstanceResource;

		public override ResourceControllerBase AddContoller()
		{
			// Create new instance of the resource to avoid refrence changes be saved on the main SO
			InstanceResource = new ItemResource(this);
			ItemController itemController = new ItemController(InstanceResource);
			return itemController;
		}

		public override ResourceBase LoadResource()
		{
			return PlayrPrefsUtility.GetData<ItemResource>(ResourceName);
		}

		public override ResourceBase SaveResource()
		{
			return PlayrPrefsUtility.SetData(ResourceName, InstanceResource);
		}
	}

}



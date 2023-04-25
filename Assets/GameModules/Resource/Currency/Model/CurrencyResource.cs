using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	[Serializable]
	public class CurrencyResource : ResourceBase
	{
		public CurrencyResource() { }

		public CurrencyResource(CurrencyResource itemResource) : base(itemResource) 
		{
			InstanceResource = this;
		}

		[JsonIgnore] public CurrencyResource InstanceResource;

		public override ResourceControllerBase AddContoller()
		{
			// Create new instance of the resource to avoid refrence changes be saved on the main SO
			InstanceResource = new CurrencyResource(this);
			CurrencyController itemController = new CurrencyController(InstanceResource);
			return itemController;
		}

		public override ResourceBase LoadResource()
		{
			CurrencyResource currencyResource = PlayrPrefsUtility.GetData<CurrencyResource>(ResourceName);
			return currencyResource == default ? this : currencyResource;
		}

		public override ResourceBase SaveResource()
		{
			return PlayrPrefsUtility.SetData(ResourceName, InstanceResource);
		}
	}

}



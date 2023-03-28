using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	[CreateAssetMenu(fileName = "ItemResource", menuName = "Resource/Item")]
	public class CurrencyResourceSO : ScriptableObjectIDDrawer
	{
		public CurrencyResource ItemResource;

		protected override void AssignNewID()
		{
			base.AssignNewID();
			ItemResource.ID = ID;
		}

	}
}



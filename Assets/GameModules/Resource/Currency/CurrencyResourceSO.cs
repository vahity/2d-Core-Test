using MH2B.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	[CreateAssetMenu(fileName = "ItemResource", menuName = "Resource/Item")]
	public class CurrencyResourceSO : ScriptableObjectIDDrawer
	{
		public CurrencyResource CurrencyResource;


		protected override void OnValidate()
		{
			base.OnValidate();
			if (!CurrencyResource.ID.Equals(ID))
			{
				CurrencyResource.ID = ID;
			}
		}

		protected override void AssignNewID()
		{
			base.AssignNewID();
			SetID();
		}

		private void SetID()
		{
			if (CurrencyResource != null)
			{
				CurrencyResource.ID = ID;
			}
			else
			{
				GeneralUtilities.SetTimer(0.1f, () => SetID());
			}
		}

	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	[CreateAssetMenu(fileName = "ResourcesContainer", menuName = "Resource/Conatiner")]
	public class ResourcesContainer : ScriptableObject
	{
		public List<ItemResourceSO> ItemResources = new List<ItemResourceSO>();
	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public abstract class ResourceIDDrawer
	{
		[ReadOnly][SerializeField] private string id;
		public string ID { get { return id; } set { id = value; } }
	}
}



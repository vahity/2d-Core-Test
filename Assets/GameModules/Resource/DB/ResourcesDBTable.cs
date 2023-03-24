using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public class ResourcesDBTable
	{
		public string ID { get; set; }
		public string Json { get; set; }

		public ResourcesDBTable(string iD, string json)
		{
			ID = iD;
			Json = json;
		}
	}
}



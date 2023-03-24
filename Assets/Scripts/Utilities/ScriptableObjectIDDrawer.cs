using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public class ScriptableObjectIDDrawer : ScriptableObject
	{
		[ReadOnly][SerializeField] private string id;
		public string ID { get { return id; } private set { id = value; } }

		protected virtual void OnValidate()
		{
			if (string.IsNullOrWhiteSpace(ID))
			{
				AssignNewID();
			}
		}

		protected virtual void Reset()
		{
			AssignNewID();
		}

		protected virtual void AssignNewID()
		{
			ID = System.Guid.NewGuid().ToString();
#if UNITY_EDITOR
			UnityEditor.EditorUtility.SetDirty(this);
#endif
		}
	}
}



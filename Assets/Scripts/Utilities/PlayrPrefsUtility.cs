using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public static class PlayrPrefsUtility
	{
		public static void ClearPrefs()
		{
			PlayerPrefs.DeleteAll();
		}

		public static T GetData<T>(string playerPrefsKey)
		{
			if (PlayerPrefs.HasKey(playerPrefsKey))
			{
				string data = PlayerPrefs.GetString(playerPrefsKey);
				T deserializedData = JsonConvert.DeserializeObject<T>(data);
				return deserializedData;
			}
			return default;
		}

		public static T SetData<T>(string playerPrefsKey, T data)
		{
			string serializedData = JsonConvert.SerializeObject(data);
			PlayerPrefs.SetString(playerPrefsKey, serializedData);
			return data;
		}
	}

}


using MH2B.GameModules.ResourceManagment;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace MH2B.GameModules.ResourceManagment
{
	public static class ResourcesDBContext
	{
		private static readonly string dbPath = "/DBContext.txt";
		private static List<ResourcesDBTable> resourcesDBTables = new List<ResourcesDBTable>();
		private static bool isDataLoaded = false;
		private static bool requestedToLoad = false;

		public static void SaveDB()
		{
			string path = Application.persistentDataPath + dbPath;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream(path, FileMode.Create);
			binaryFormatter.Serialize(fileStream, resourcesDBTables);
			fileStream.Close();
		}

		public static List<ResourcesDBTable> LoadDB()
		{
			if(requestedToLoad) return resourcesDBTables;
			requestedToLoad = true;
			isDataLoaded = false;
			string path = Application.persistentDataPath + dbPath;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			resourcesDBTables = binaryFormatter.Deserialize(fileStream) as List<ResourcesDBTable>;
			fileStream.Close();
			isDataLoaded = true;
			return resourcesDBTables;
		}

		private static async Task WaitForDataToLoad()
		{
			while (!isDataLoaded)
			{
				LoadDB();
				await Task.Delay(100);
			}
		}

		public static async Task InsertOrUpdateTable<T>(T resource) where T : ResourceIDDrawer
		{
			await WaitForDataToLoad();
			string json = JsonConvert.SerializeObject(resource);
			ResourcesDBTable resourcesDBTable = new ResourcesDBTable(resource.ID , json);
			var foundItem = resourcesDBTables.Find(x => x.ID.Equals(resource.ID));
			if (foundItem == null)
			{
				resourcesDBTables.Add(resourcesDBTable);
			}
			else
			{
				string jsonTable = JsonConvert.SerializeObject(resourcesDBTable);
				foundItem = new ResourcesDBTable(foundItem.ID, jsonTable);
			}

		}

		public static async Task<T> LoadTableAsync<T>(T resource) where T : ResourceIDDrawer
		{
			await WaitForDataToLoad();
			var foundItem = resourcesDBTables.Find(x => x.ID.Equals(resource.ID));
			if(foundItem == null )
			{
				throw new Exception($"Resource not found {resource.ID}");
			}
			return JsonConvert.DeserializeObject<T>(foundItem.Json);
		}

		public static async Task DeleteTableAsync<T>(T resource) where T : ResourceIDDrawer
		{
			await WaitForDataToLoad();
			var foundItem = resourcesDBTables.Find(x => x.ID.Equals(resource.ID));
			if (foundItem == null)
			{
				throw new Exception($"Resource not found {resource.ID}");
			}
			resourcesDBTables.Remove(foundItem);
		}
	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class StartupScript : MonoBehaviour
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void Startup()
    {
		GameObject dIHandler = Resources.Load<GameObject>("Prefabs/DIHandler/DIHandlerPrefab");
		GameObject GameModules = Instantiate(dIHandler);
		DontDestroyOnLoad(GameModules);
	}
}

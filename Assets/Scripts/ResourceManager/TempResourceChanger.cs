using MH2B.GameModules.ResourceManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempResourceChanger : MonoBehaviour
{
    [SerializeField] private string resourceName;
    [SerializeField] private bool isAvailable;
    [SerializeField] private int value;

    [ContextMenu("Apply")]
    private void Apply()
    {
        ResourcesUtilities.SetAvailibility(resourceName, isAvailable);
		ResourcesUtilities.SetValue(resourceName, value);
        ResourcesUtilities.SaveResource(resourceName);
	}

}

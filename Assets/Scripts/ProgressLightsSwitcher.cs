using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressLightsSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> lights = new List<GameObject>();

    public void SetProgress(int index)
    {
        if (index >= lights.Count) return;
        foreach(var light in lights)
        {
			light.SetActive(false);
		}
        for(int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(true);
        }
    }

}

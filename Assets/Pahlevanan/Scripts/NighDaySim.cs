using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NighDaySim : MonoBehaviour
{


    public float cycleDuration = 20f;
    public Color dayColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    public Color nightColor = new Color(0.1f, 0.1f, 0.1f, 1f);
    private float currentLerpTime = 0f;
    private bool isNight = false;

    void Update()
    {
        if (!isNight)
        {
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > cycleDuration)
            {
                currentLerpTime = cycleDuration;
                isNight = true;
            }
        }
        else
        {
            currentLerpTime -= Time.deltaTime;

            if (currentLerpTime < 0f)
            {
                currentLerpTime = 0f;
                isNight = false;
            }
        }

        float t = currentLerpTime / cycleDuration;
        Color newColor = Color.Lerp(dayColor, nightColor, t);

        GameObject[] backgroundPrefabs = GameObject.FindGameObjectsWithTag("backgroundprefab");
        foreach (GameObject backgroundPrefab in backgroundPrefabs)
        {
            backgroundPrefab.GetComponent<SpriteRenderer>().color = newColor;
        }
    }

}

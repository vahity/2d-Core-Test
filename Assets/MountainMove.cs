using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMove : MonoBehaviour
{
    public bool sc;
    public float x;
    // Update is called once per frame
    void Update()
    {
        if (sc == true)
        {
            transform.Translate(x, 0, 0);
        }
       
    }
    public void PauseGame()
    {
        sc = false;
    }
    public void ResumeGame()
    {
        sc = true;

    }
}

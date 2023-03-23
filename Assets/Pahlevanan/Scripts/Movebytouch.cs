using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class Movebytouch : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
     for(int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchposition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        }
        
    }
}

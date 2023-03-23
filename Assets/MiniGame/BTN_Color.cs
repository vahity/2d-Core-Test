using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BTN_Color : MonoBehaviour
{
    public Code c;
    Image selfcolor;
    void Start()
    {
        selfcolor = GetComponent<Image>();
        int colorchance = Random.Range(0,4);
        selfcolor.color = c.btn_color[colorchance];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

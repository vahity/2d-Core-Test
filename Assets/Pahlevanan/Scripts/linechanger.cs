using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class linechanger : MonoBehaviour
{
    
   // public float scale1 = 2f;
   // public float scale2 = 3f;
   // public float scale3 = 0.5f;

    public static linechanger instance;

    public GameObject Empty1;
    public GameObject Empty2;
    public GameObject Empty3;

    public int ChangeLine;

    BoxCollider2D playerbox;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ChangeLine = 2;
        playerbox = GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {


        if (Empty1.activeSelf)
        {
            if (ChangeLine == 0)
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(Empty1.transform.position.x, Empty1.transform.position.y);
                
                touch.instance.IsChange = true;
               // transform.localScale *= scaleFactor1;

            }
        }

        if (Empty2.activeSelf)
        {
            if (ChangeLine == 1)
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(Empty2.transform.position.x, Empty2.transform.position.y);
                touch.instance.IsChange = true;
                // transform.localScale *= scaleFactor2;
             //  Vector3 newScale = new Vector3(scale2, scale2, scale2);
            }


        }


        if (Empty3.activeSelf)
        {
            if (ChangeLine == 2)
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(Empty3.transform.position.x, Empty3.transform.position.y);
                touch.instance.IsChange = true;
                playerbox.size = new Vector2 (playerbox.size.x ,10f);
                //transform.localScale *= scaleFactor3;
            }
        }

         if (ChangeLine >= 2 || ChangeLine <= 0)
        {
            touch.instance.IsChange = false;
        }
      
    }
}
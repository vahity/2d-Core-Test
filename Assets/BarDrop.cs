using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDrop : MonoBehaviour
{
    public GameObject[] bars;
    public  static  int ii = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chale"))
        {
           // bars[ii].gameObject.transform.SetParent(null);
            bars[ii].AddComponent<Rigidbody2D>();
            Debug.Log("bardrop");
            ii++;
        }
    }

}

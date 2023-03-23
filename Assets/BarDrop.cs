using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDrop : MonoBehaviour
{
    public GameObject[] bars;
    public int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snow"))
        {
            bars[i].gameObject.transform.SetParent(null);
            bars[i].AddComponent<Rigidbody2D>();
            Debug.Log("bardrop");
            i++;
        }
    }

}

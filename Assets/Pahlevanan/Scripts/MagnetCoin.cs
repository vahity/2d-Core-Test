using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MagnetCoin : MonoBehaviour
{
    public CircleCollider2D coinCollider;
    public float originalColliderSize;
    // Start is called before the first frame update
    void Start()
    {
        coinCollider = GetComponent<CircleCollider2D>();
        originalColliderSize = coinCollider.radius;
        // SetColliderSize(18);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SetColliderSize(float size)
    {
        coinCollider.radius = size;
        Debug.Log("Magnet");
        yield return new WaitForSeconds(4f);
        coinCollider.radius = originalColliderSize;
        Debug.Log("Dimagnet");
    }
    public void SetColliderSize1()
    {
        
        StartCoroutine(SetColliderSize(20f));
        Debug.Log("magnet1");
        
    }
}

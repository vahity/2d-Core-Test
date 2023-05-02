using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MagnetCoin : MonoBehaviour
{
    public CircleCollider2D coinCollider;
    public float originalColliderSize;
    public static  bool MagnetAnimm=false;
    // Start is called before the first frame update
    void Start()
    {
     //   coinCollider = GetComponent<CircleCollider2D>();
      //  originalColliderSize = coinCollider.radius;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  SetColliderSize(float size)
    {
        // Find all gameobjects with tag "Coin"
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");

        // Loop through all coins and set their collider size
        foreach (GameObject coin in coins)
        {
           
            CircleCollider2D coinCollider = coin.GetComponent<CircleCollider2D>();
            float originalColliderSize = coinCollider.radius;

            coinCollider.radius = size;
            Debug.Log("Magnet");
            // yield return new WaitForSeconds(4f);
            //  coinCollider.radius = originalColliderSize;
            //  Debug.Log("Dimagnet");
        }
      //  yield return new WaitForSeconds(3f);
      //  MagnetAnimm = false;
      //  DiMagent();
      //  foreach (GameObject coin in coins)
      //  {
      //      CircleCollider2D coinCollider = coin.GetComponent<CircleCollider2D>();
      //     // float originalColliderSize = coinCollider.radius;
      //      coinCollider.radius = 2;
      //      Debug.Log("DiiiiiMagnet");
      //  }
           
    }
    IEnumerator DiMagent()
    {
        yield return new WaitForSeconds(3f);
        MagnetAnimm = false;
        coinCollider.radius = 2;
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject coin in coins)
        {
            Debug.Log(coin);

            CircleCollider2D coinCollider = coin.GetComponent<CircleCollider2D>();
            // float originalColliderSize = coinCollider.radius;
            coinCollider.radius = 2;
            Debug.Log("DiiiiiMagnet");
        }
    }

    public void SetColliderSize1()
    {
        MagnetAnimm=true;
        SetColliderSize(40f);
       
       StartCoroutine(DiMagent());
        Debug.Log("TAhClassSetCollder  Size");

    }
}

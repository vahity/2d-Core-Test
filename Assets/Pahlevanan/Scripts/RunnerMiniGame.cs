using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMiniGame : MonoBehaviour
{
    private Rigidbody2D rb;
     public int  rightspeed = 20;
    public int dirx = 10;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TransformPlayerPositionIn()
    {
       // transform.position = Vector3.MoveTowards(transform.position, new Vector3(-300f, 165f, 0f), 1 * Time.deltaTime);
    }
    public void Righ()
    {
        Debug.Log("right");
        rb.velocity = new Vector2(+dirx * rightspeed, rb.velocity.y);

    }
    public void left()
    {
        Debug.Log("left");
        rb.velocity = new Vector2(-dirx * rightspeed, rb.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //سلام وحید چطوری :)
    Rigidbody2D rb;
    //این ویکتور قراره بیاد جای ویکتور بازیکن
    Vector2 Movement;
    public float MoveSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //این کد باعث میشه که مقدار عددی دکمه ها ریخته بشع توی مقتصاد حرکت
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertcal");
    }
    void FixedUpdate()
    {
        rb.MovePosition( rb.position + Movement * MoveSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public float fireRate = 5.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    private float nextFire = 0.0f;

    private void Update()
    {
        if (target != null)
        {
            // ????? ???? ??????? ???? ?? ????
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // ???? ???? ?? ??? ??????? ????
            if (Time.time > nextFire)
            {
                nextFire = Time.time + 1.0f / fireRate;
                Invoke("Shoot", 10f);
               // Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }
}
    



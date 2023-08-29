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
    public static bool BullWar = false;
    



    public Transform targetPosition1;
    public Transform targetPosition2;
    public Transform targetPosition3;



    private float nextFire = 0.0f;

    private void Update()
    {
        if (target != null)
        {

            if (PlayerMovment.x==0)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition1.position, speed * Time.deltaTime);
            }
            else if (PlayerMovment.x == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition2.position, speed * Time.deltaTime);
            }
            else if (PlayerMovment.x == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition3.position, speed * Time.deltaTime);
            }
            else if  (PlayerMovment.x >= 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }


            if (Time.time > nextFire)
            {
                nextFire = Time.time + 1.0f / fireRate;
                Invoke("Shoot", 9f);
               

             
               
            }
        }


        


    }
    

    public  void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
        BullWar = true;
        StartCoroutine(Warning());

    }
    IEnumerator Warning()
    {
        yield return new WaitForSeconds(0.7f);
        BullWar = false;
        yield return new WaitForSeconds(0.4f);
        BullWar = true;
        yield return new WaitForSeconds(0.7f);
        BullWar = false;
        yield return new WaitForSeconds(0.4f);
        BullWar = true;
        yield return new WaitForSeconds(0.7f);
        BullWar = false;
    }







}
    



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointfollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentwaypointIndex = 0;


    [SerializeField] private float speed = 2f;

    private void Update()
    {
       if (Vector2.Distance(waypoints[currentwaypointIndex].transform.position, transform.position) < .1f)
        {
            currentwaypointIndex++;
            if (currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 0;
                Destroy(gameObject);
            }
        }


        if (Vector2.Distance(waypoints[currentwaypointIndex].transform.position, transform.position) < .1f)
        {
            currentwaypointIndex++;
            if (currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 0;
                Destroy(gameObject);
            }
        }



        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * speed);
        
    }

}

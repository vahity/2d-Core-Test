using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follower : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 5f;
    [SerializeField] private float yOffset = 1f;
    public Transform target;
    void Update()
    {
       Vector3 newPos = new Vector3(target.position.x+4, (target.position.y)*0 + yOffset, -10f); 
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        
    }
}

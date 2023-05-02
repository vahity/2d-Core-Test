using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follower : MonoBehaviour
{
    public static float FollowSpeed = 0.01f;
    [SerializeField] private float yOffset = 0f;
    [SerializeField] private float xStartPos = 0f;
    public Transform target;
     void Start()
    {
        Vector3 newPos = new Vector3(xStartPos, yOffset, -10f);
    }
    void Update()
    {
       Vector3 newPos = new Vector3(target.position.x+4,yOffset, -10f); 
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeReference] private Transform Player;
    [SerializeField] private float yOffset = 1f;
    void Update()
    {
        transform.position = new Vector3(Player.position.x+6, (Player.position.y*0) + yOffset, transform.position.z);  
    }
}

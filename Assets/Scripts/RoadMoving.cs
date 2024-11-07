using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoving : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    private int currentWaypoint = 0;
    [SerializeField] public static float speed = 0.03f;
    
    void Update()
    {
      transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,-1000), speed);
    }
}

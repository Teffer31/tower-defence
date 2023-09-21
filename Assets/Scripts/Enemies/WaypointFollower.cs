using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, Time.deltaTime * speed); //moves the enemy

        if (Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position) <= reachedWaypointClearance) //check distance between the Enemy and the next waypoint
        {
            nextWaypointIndex += 1; //goes to next waypoint
        }
        if(nextWaypointIndex >= waypoints.Length)  //checks if the nextWaypointIndex is greater or equal than the amount of waypoints
        {
            nextWaypointIndex = 0; //sets waypoint back to zero
        }
    }
}

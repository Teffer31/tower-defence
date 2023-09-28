using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;
    [SerializeField] private Path path;

    void Awake()
    {
        path = FindObjectOfType<Path>(); //finds the game ombject "path"
    }

    void Start()
    {
        transform.position = path.waypoints[0].position; //Set the Enemy position to the first waypoint position
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed); //moves the enemy

        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance) //check distance between the Enemy and the next waypoint
        {
            nextWaypointIndex += 1; //goes to next waypoint
        }

        if(nextWaypointIndex >= path.waypoints.Length)  //checks if the nextWaypointIndex is greater or equal than the amount of waypoints
        {
            nextWaypointIndex = 0; //sets waypoint back to zero
        }
    }
}

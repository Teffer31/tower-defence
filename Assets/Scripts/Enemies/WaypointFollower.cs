using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;
    [SerializeField] private Path path;

    // Use a property for 'path' to allow more control.
    private Path Path
    {
        get
        {
            if (path == null)
            {
                path = FindObjectOfType<Path>();
            }
            return path;
        }
    }

    void Start()
    {
        // Check if the waypoints array is empty to avoid errors.
        if (Path.waypoints.Length > 0)
        {
            transform.position = Path.waypoints[0].position;
        }
    }

    void Update()
    {
        // Check if there are waypoints before moving.
        if (Path.waypoints.Length > 0)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, Path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, Path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance)
        {
            // Check if the next waypoint is the last one before destroying the object.
            if (nextWaypointIndex == Path.waypoints.Length - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                nextWaypointIndex += 1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform target;

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy"); //get all gameobjects from the scene with the tag "Enemy"

        if (targets.Length == 0) //stops tower if there is no enemy to target
        { 
            return; 
        }

        Transform target = targets[0].transform;
    }

    public void LookAtTarget()
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}

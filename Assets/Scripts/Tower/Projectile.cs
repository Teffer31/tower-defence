using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Transform target; 
    [SerializeField] private float speed = 10; 


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destroy the projectile if it has no target
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        // Move the projectile towards its target using linear interpolation
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject); // Destroy the projectile when it collides with an enemy
            Destroy(other.gameObject); // Destroy the enemy it collided with
        }
    }
}

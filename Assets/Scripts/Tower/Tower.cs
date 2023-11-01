using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; 
    [SerializeField] private float shootInterval = 1.0f;
    [SerializeField] private float shootingRadius = 5.0f; 
    [SerializeField] private Transform bulletcase; 
    [SerializeField] private Transform rotationObject; 

    private Transform target; 

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        FindTarget(); // Update the towers target based on enemies within range
    }

    void FindTarget()
    {
        // Find all enemy colliders within the towers shooting radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, shootingRadius);

        target = null; 
        float nearestDistance = shootingRadius; // Initialize with the shooting radius

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Calculate the distance between the tower and the enemy
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                // Check if this enemy is closer than the current target
                if (distance < nearestDistance)
                {
                    target = collider.transform; // Set the closest enemy as the new target
                    nearestDistance = distance; // Update the nearest distance
                }
            }
        }

        if (target != null)
        {
            LookAtTarget(); // Rotate the specified object to face the target
        }
    }

    void LookAtTarget()
    {
        Vector2 direction = target.position - transform.position;
        rotationObject.up = direction; // Rotate the specified object to face the target
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (target != null)
            {
                yield return new WaitForSeconds(shootInterval); // Wait for the shoot interval

                // Instantiate a projectile and set its target
                GameObject projectileGameObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity, bulletcase);
                Projectile projectile = projectileGameObject.GetComponent<Projectile>();
                projectile.target = target;
            }
            else
            {
                yield return null;
            }
        }
    }
}

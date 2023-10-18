using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy"); //get all gameobjects from the scene with the tag "Enemy"

        if (targets.Length == 0) //stops tower if there is no enemy to target
        { 
            return; 
        }

        float nearestDistance = 100;
        for (int i = 0; i < targets.Length; i++) 
        {
            float distance = Vector2.Distance(transform.position, targets[i].transform.position);
            if (distance < nearestDistance)
            {
                target = targets[i].transform;
                nearestDistance = distance;
            }
        }

        LookAtTarget();
    }

    public void LookAtTarget()
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    public IEnumerator Shoot()
    {       
        while (true) 
        {
            yield return new WaitForSeconds(shootInterval);
            GameObject projectileGameObject = Instantiate(projectilePrefab);
            Projectile projectile = projectileGameObject.GetComponent<Projectile>();
            projectile.target = target;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private float spawnInterval = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (enemyPrefabs.Count > 0)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Count);
                GameObject randomEnemy = enemyPrefabs[randomIndex];
                Instantiate(randomEnemy, transform.position, Quaternion.identity);
            }
        }
    }
}

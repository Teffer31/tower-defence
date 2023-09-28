using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    

    void Start()
    {
        StartCoroutine("SpawnEnemy"); //starts the function
    }

    IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1); //spawns enemy prefab every 1 second
            Instantiate(enemyPrefab);
        }
    }
}

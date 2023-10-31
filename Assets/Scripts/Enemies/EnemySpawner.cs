using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject bee;
    [SerializeField] private GameObject wolf;


    void Start()
    {
        StartCoroutine("SpawnEnemy"); //starts the function
    }

    IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1); //spawns enemy prefab every 1 second
            Instantiate(slime);
            Instantiate(bee);
            Instantiate(wolf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemyPrefab);
        }
    }
}

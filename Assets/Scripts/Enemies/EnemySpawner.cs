using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Round
    {
        public List<GameObject> enemiesToSpawn;     
        public float delayBetweenEnemies = 1.0f;   
    }

    [SerializeField] private List<Round> rounds = new List<Round>();  
    private int currentRound = 0;          
    private int currentEnemyIndex = 0;      

    private void Start()
    {
        StartCoroutine(SpawnRounds());   
    }

    // Coroutine for spawning rounds of enemies.
    IEnumerator SpawnRounds()
    {
        while (currentRound < rounds.Count)
        {
            Round round = rounds[currentRound];    // Get the current round
            List<GameObject> enemies = round.enemiesToSpawn;  // Get the list of enemy prefabs for this round
            float delay = round.delayBetweenEnemies;   // Get the delay between enemy spawns in this round

            while (currentEnemyIndex < enemies.Count)
            {
                // Instantiate the current enemy prefab at the spawner position with no rotation.
                Instantiate(enemies[currentEnemyIndex], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(delay);  // Wait for the specified delay before spawning the next enemy
                currentEnemyIndex++;  // Move to the next enemy in the list
            }

            currentRound++;          // Move to the next round
            currentEnemyIndex = 0;   // Reset the enemy index for the new round

            if (currentRound < rounds.Count)
            {
                yield return new WaitForSeconds(3.0f); 
            }
        }
    }
}

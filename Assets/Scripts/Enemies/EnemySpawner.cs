using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Round
    {
        public List<GameObject> enemiesToSpawn;
        public float timeBetweenSpawns = 1.0f;
    }

    [SerializeField] private List<Round> rounds = new List<Round>();
    private int currentRound = 0;
    private int currentEnemyIndex = 0;
    private bool roundInProgress = false;

    private void Start()
    {
        StartCoroutine(ManageRounds());
    }

    IEnumerator ManageRounds()
    {
        while (currentRound < rounds.Count)
        {
            if (!roundInProgress)
            {
                StartCoroutine(StartRound());
            }
            yield return null;
        }
    }

    IEnumerator StartRound()
    {
        roundInProgress = true;
        Round round = rounds[currentRound];
        List<GameObject> enemies = round.enemiesToSpawn;
        float spawnDelay = round.timeBetweenSpawns;

        yield return new WaitForSeconds(3.0f); // Delay before starting the round.

        while (currentEnemyIndex < enemies.Count)
        {
            Instantiate(enemies[currentEnemyIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
            currentEnemyIndex++;
        }

        // Wait until all enemies in the round are defeated.
        while (currentEnemyIndex > 0)
        {
            yield return null;
        }

        currentRound++;
        currentEnemyIndex = 0;
        roundInProgress = false;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemyCount;
    public int waveCount = 1;

     public Transform[] SpawnPoints;
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnPoints[Random.Range(0, 
                SpawnPoints.Length)].position, enemyPrefab.transform.rotation);
        }

        waveCount++;
    }
}

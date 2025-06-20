using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public TextMeshProUGUI waveText;
    public int enemyCount;
    public int waveCount = 1;

    public Transform[] SpawnPoints;

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
        UpdateWaveUI();

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnPoints[Random.Range(0, SpawnPoints.Length)].position, enemyPrefab.transform.rotation);
        }

        waveCount++;
    }

    void UpdateWaveUI()
    {
        waveText.text = "Wave " + waveCount;
    }
}

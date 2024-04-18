using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int enemiesNumber;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerupPrefab;
    float spawnRange = 9f;
    int enemyWaveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesNumber <= 0)
        {
            enemyWaveNumber++;
            SpawnWave(enemyWaveNumber);
        }
    }

    void SpawnWave(int num)
    {
        enemiesNumber = num;
        for (int i = 0; i < num; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);
        return new Vector3 (x, 0.45f, z);
    }
}

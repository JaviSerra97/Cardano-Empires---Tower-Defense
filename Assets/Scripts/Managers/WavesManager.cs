using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class WavesManager : Singleton<WavesManager>
{
    [System.Serializable]
    public class Wave
    {
        public string ID;
        public List<WaveEnemy> Enemies;
        public float duration;
    }

    [System.Serializable]
    public class WaveEnemy
    {
        public string ID;
        public GameObject enemy;
        public float spawnTime;
        public Transform spawnPoint;
    }

    [SerializeField] private Transform enemiesParent;

    [SerializeField] private List<Wave> listOfWaves;

    [SerializeField] private float forceNextWaveDelay;

    private int currentWaveIndex = 0;
    private float waveTimer;
    private int currentEnemyIndex = 0;
    private float enemyTimer;

    private WaveEnemy nextEnemy;
    private Wave currentWave;

    private List<GameObject> spawnedEnemies;
    private bool levelStarted = false;

    private void Start()
    {
        SetCurrentWave();
    }

    private void Update()
    {
        waveTimer += Time.deltaTime;
        if(waveTimer >= currentWave.duration)
        {
            StartNextWave();
        }

        enemyTimer += Time.deltaTime;
        if(enemyTimer >= nextEnemy.spawnTime)
        {
            SpawnEnemy();
            //enemyTimer = 0;
        }

        if(levelStarted && spawnedEnemies.Count == 0) { StartNextWave(); }
    }

    void SpawnEnemy()
    {
        GameObject e = Instantiate(nextEnemy.enemy, nextEnemy.spawnPoint.position, Quaternion.identity, enemiesParent);
        spawnedEnemies.Add(e);

        currentEnemyIndex++;
        SetNextEnemy();

        levelStarted = true;
    }

    void SetNextEnemy()
    {
        nextEnemy = currentWave.Enemies[currentEnemyIndex];
    }

    void SetCurrentWave()
    {
        currentWave = listOfWaves[currentWaveIndex];

        SetNextEnemy();
    }

    void StartNextWave()
    {
        currentEnemyIndex = 0;
        enemyTimer = 0;
        waveTimer = 0;

        currentWaveIndex++;

        SetCurrentWave();
    }

    public void RemoveEnemy(GameObject e) { spawnedEnemies.Remove(e); }

}

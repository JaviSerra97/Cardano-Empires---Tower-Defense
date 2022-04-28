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
        public UnityEngine.GameObject enemy;
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

    private List<UnityEngine.GameObject> spawnedEnemies = new List<UnityEngine.GameObject>();
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
        if(nextEnemy != null && enemyTimer >= nextEnemy.spawnTime)
        {
            SpawnEnemy();
            //enemyTimer = 0;
        }

        if(levelStarted && spawnedEnemies.Count == 0) { StartNextWave(); }
    }

    void SpawnEnemy()
    {
        if(nextEnemy == null){return;}
        
        UnityEngine.GameObject e = Instantiate(nextEnemy.enemy, nextEnemy.spawnPoint.position, Quaternion.identity, enemiesParent);
        spawnedEnemies.Add(e);
        Debug.Log("instanciar enemigo");

        currentEnemyIndex++;
        SetNextEnemy();

        levelStarted = true;
    }

    void SetNextEnemy()
    {
        if (currentWave.Enemies.Count > currentEnemyIndex)
        {
            nextEnemy = currentWave.Enemies[currentEnemyIndex];
        }
        else
        {
            nextEnemy = null;
        }
    }

    void SetCurrentWave()
    {
        currentWave = listOfWaves[currentWaveIndex];

        SetNextEnemy();
    }

    void StartNextWave()
    {
        if (listOfWaves.Count - 1 > currentWaveIndex)
        {
            Debug.Log("Siguiente oleada");
            currentEnemyIndex = 0;
            enemyTimer = 0;
            waveTimer = 0;

            currentWaveIndex++;

            SetCurrentWave();
        }
        else
        {
            Debug.Log("No hay mas oleadas");
        }
    }

    public void RemoveEnemy(UnityEngine.GameObject e) { spawnedEnemies.Remove(e); }

}

using System;
using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private PoolManager poolManager;

    private WaveSO currentWave;
    private Transform[] _waypoints;
    private bool isSpawning;


    public void Startwave(int waveIndex)
    {
        if (isSpawning || currentWave == null)
        {
            Debug.LogWarning("No Wave Loaded");
            return;
        }
        gameEvents.RaiseOnWaveStarts(waveIndex);
        isSpawning = true;
        StartCoroutine(SpawnWave());

    }
    /// Loads the wave data and Waypoints
    public void Loadwave(WaveSO waveSO, Transform[] waypoints)
    {
        if (isSpawning)
        {
            Debug.LogWarning("Already Spawning a wave");
            return;
        }
        currentWave = waveSO;
        _waypoints = waypoints;
    }
    /// Spawns enemies based on the current wave's enemy spawn list.
    /// Spawns With proper delay
    private IEnumerator SpawnWave()
    {
        isSpawning = true;
        for (int i = 0; i < currentWave.enemySpawns.Count; i++)
        {
            var spawn = currentWave.enemySpawns[i];

            for (int j = 0; j < spawn.count; j++)
            {
                SpawnEnemy(spawn.enemySO);
                yield return new WaitForSeconds(spawn.spawnDelay);
            }
        }
        isSpawning = false;
        gameEvents.RaiseOnEnemyReached();//All the enemies have been reached the base.
    }

    /// spawns an  enemy based on the enemySO 
    private void SpawnEnemy(EnemySO enemySO)
    {
        GameObject enemyObj = poolManager.GetEnemy(enemySO);
        enemyObj.transform.position = _waypoints[0].position;
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.Init(enemySO, _waypoints);
        Debug.Log(enemyObj.name + " | ID: " + enemyObj.GetInstanceID());
    }

    public void CheckWaveComplete()
    {
        if (EnemyStats.GetAll().Count == 0 && !isSpawning)
        {
            Debug.Log("Wave Completed");
            gameEvents.RaiseOnWaveCompleted();
        }
    }


}

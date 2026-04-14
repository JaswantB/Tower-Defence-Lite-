using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private List<WaveSO> waves;
    [SerializeField] private Transform[] _waypoints;

    private int currentWaveIndex = 0;

    private void OnEnable()
    {
        gameEvents.OnWaveCompleted += LoadNextWave;
    }
    private void OnDisable()
    {
        gameEvents.OnWaveCompleted -= LoadNextWave;
    }

    private void Start()
    {
        currentWaveIndex = 0;
        LoadNextWave();

    }
    private void LoadNextWave()
    {
        if (currentWaveIndex >= waves.Count)
        {
            Debug.Log("All waves completed!");
            gameEvents.RaiseOnVictory();
            return;
        }
        WaveSO wave = BuildWaves(waves[currentWaveIndex]);
        waveManager.Loadwave(wave, _waypoints);
        waveManager.Startwave(currentWaveIndex + 1);
        currentWaveIndex++;
    }
    private WaveSO BuildWaves(WaveSO waveSO)
    {
        float multiplier = 1f + (currentWaveIndex * 0.1f); // Increase difficulty by 10% each wave
        WaveSO waveScale = Instantiate(waveSO);
        return waveSO;
    }

}

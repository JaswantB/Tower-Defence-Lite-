using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/GameEvents")]
public class GameEvents : ScriptableObject
{
    public event Action<int> OnCoinChanged;
    public event Action<int> OnLivesChanged;
    public event Action<int> OnWaveStarted;
    public event Action OnEnemyReachedBase;
    public event Action OnGameOver;
    public event Action OnVictory;

    public void RaiseOnCoinChanged(int amount)
    {
        OnCoinChanged?.Invoke(amount);
    }

    public void RaiseOnLivesChanged(int lives)
    {
        OnLivesChanged?.Invoke(lives);
    }
    public void RaiseOnWaveStarts(int Waves)
    {
        OnWaveStarted?.Invoke(Waves);
    }
    public void RaiseOnEnemyReached()
    {
        OnEnemyReachedBase?.Invoke();
    }
    public void RaiseOnGameOver()
    {
        OnGameOver?.Invoke();
    }
    public void RaiseOnVictory()
    {
        OnVictory?.Invoke();
    }
}


using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private int initialMoney = 1000;
    [SerializeField] private int initialLives = 20;

    private int coins;
    private int lives;

    private void OnEnable()
    {
        gameEvents.OnCoinChanged += UpdateCoins;
        gameEvents.OnEnemyReachedBase += LoseLives;
        gameEvents.OnSpendCoins += HandleSpendCoins;
    }

    private void OnDisable()
    {
        gameEvents.OnCoinChanged -= UpdateCoins;
        gameEvents.OnEnemyReachedBase -= LoseLives;
        gameEvents.OnSpendCoins -= HandleSpendCoins;
    }

    private void Start()
    {
        coins = initialMoney;
        lives = initialLives;
    }
    private void UpdateCoins(int amount)
    {
        Debug.Log("Coins: " + coins);
        coins += amount;
    }
    private void LoseLives()
    {
        Debug.Log("Lives: " + lives);
        lives--;
        gameEvents.RaiseOnLivesChanged(lives);

        if (lives <= 0)
        {
            gameEvents.RaiseOnGameOver();
        }
    }
    private void HandleSpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins-=amount;
            gameEvents.RaiseOnCoinChanged(-amount);
            gameEvents.RaiseOnSpendCoinsResult(true);

        }
        else
        {
            gameEvents.RaiseOnSpendCoinsResult(false);
        }
    }
}

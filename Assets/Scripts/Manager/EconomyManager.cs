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
    }

    private void OnDisable()
    {
        gameEvents.OnCoinChanged -= UpdateCoins;
        gameEvents.OnEnemyReachedBase -= LoseLives;
    }

    private void Start()
    {
        coins=initialMoney;
        lives=initialLives;
    }
    private void UpdateCoins(int amount)
    {
        Debug.Log("Coins: " + coins);
        coins += amount;
    }
    private void LoseLives()
    {
        Debug.Log("Lives: " + lives);
        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            gameEvents.RaiseOnGameOver();
        }
        else
        {
            lives--;
            gameEvents.RaiseOnLivesChanged(lives);
        }
    }
    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            gameEvents.RaiseOnCoinChanged(-amount);
            return true;
        }
        return false;
    }
    public int GetCoins()
    {
        return coins;
    }
    public int GetLives()
    {
        return lives;
    }
}

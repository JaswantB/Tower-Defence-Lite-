using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField]private GameEvents gameEvents;
    [SerializeField]private TextMeshProUGUI coinsText;
    [SerializeField]private TextMeshProUGUI waveText;
    [SerializeField]private TextMeshProUGUI livesText;

    private int currentCoins;

    private void OnEnable()
    {
        gameEvents.OnCoinChanged+=HandleCoins;
        gameEvents.OnLivesChanged+=HandleLives;
        gameEvents.OnWaveStarted+=HandleWave;
    }
    void OnDisable()
    {
        gameEvents.OnCoinChanged-=HandleCoins;
        gameEvents.OnLivesChanged-=HandleLives;
        gameEvents.OnWaveStarted-=HandleWave;
    }
    private void HandleCoins(int amount)
    {
        currentCoins +=amount;
        Debug.Log("Coins Updated: " + currentCoins);
        coinsText.text = currentCoins.ToString();
    }
    private void HandleLives(int lives)
    {
        Debug.Log("Lives: " + lives);
        livesText.text =lives.ToString();
    }
    private void HandleWave(int waveNumber)
    {
        Debug.Log("Wave: " + waveNumber);
        waveText.text =waveNumber.ToString();
    }
    
}

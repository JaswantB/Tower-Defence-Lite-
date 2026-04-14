using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]private GameEvents gameEvents;
    [SerializeField]private GameObject HudPanel;
    [SerializeField]private GameObject GameOverPanel;
    [SerializeField]private GameObject VictoryPanel;

    private void OnEnable()
    {
        gameEvents.OnGameOver += ShowGameOverScreen;
        gameEvents.OnVictory += ShowVictoryScreen;
    }
    private void OnDisable()
    {
        gameEvents.OnGameOver -= ShowGameOverScreen;
        gameEvents.OnVictory -= ShowVictoryScreen;
    }

    private  void ShowGameOverScreen()
    {
        HudPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
    private void ShowVictoryScreen()
    {
        HudPanel.SetActive(false);
        VictoryPanel.SetActive(true);
    }
}

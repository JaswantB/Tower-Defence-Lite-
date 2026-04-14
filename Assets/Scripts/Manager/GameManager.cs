using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField]private LevelGenerator levelGenerator;
    private bool isGameOver=false;

    private void OnEnable()
    {
        gameEvents.OnGameOver += HandleGameOver;
        gameEvents.OnVictory += HandleVictory;
    }
    private void OnDisable()
    {
        gameEvents.OnGameOver -= HandleGameOver;
        gameEvents.OnVictory -= HandleVictory;
    }
    private void Start()
    {
        isGameOver=false;

    }
    private void HandleGameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
    }
    private void HandleVictory()
    {
        isGameOver = true;
        Debug.Log("Victory!");
    }
}

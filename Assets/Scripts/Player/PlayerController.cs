using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;

    private TowerSO towerSO;
    private TowerSpots towerSpots;
    private bool isGameOver = false;

    private void OnEnable()
    {
        gameEvents.OnGameOver += HandleGameOver;
        gameEvents.OnVictory += HandleVictory;
        gameEvents.OnPurchaseSuccess += HandlePurchaseSuccess;
    }
    private void OnDisable()
    {
        gameEvents.OnGameOver -= HandleGameOver;
        gameEvents.OnVictory -= HandleVictory;
        gameEvents.OnPurchaseSuccess -= HandlePurchaseSuccess;
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

    private void HandlePurchaseSuccess()
    {
        Debug.Log("Purchase successful!");
        if (towerSpots == null)
        {
            Debug.LogError("TowerSpots reference is missing!");
            return;
        }
        Instantiate(towerSO.towerPrefab, towerSpots.transform.position, quaternion.identity);
        towerSpots.OccupySpot(true);
        towerSpots = null;
        towerSO = null;
    }
    public void SelectTower(TowerSO tower)
    {
        towerSO = tower;
    }
    private void Update()
    {
        if (isGameOver == true)
        {
            return;
        }
        HandleTowerPlacement();
        Debug.Log("HandleTowerPlacement running");
    }
    private void HandleTowerPlacement()
    {
        if (towerSO == null)
        {
            return;
        }
        if (!Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
        {
            Debug.Log("No hit detected");
            return;
        }
        Debug.Log("Hit: " + hit.collider.name);
        if (hit.collider.TryGetComponent<TowerSpots>(out TowerSpots spot))
        {
            Debug.Log("Clicked on Tower Spot: " + spot.name);
            if (spot.isOccupied == true)
            {
                Debug.Log("Spot is already occupied!");
                return;
            }
            towerSpots = spot;
            Debug.Log("Spawning tower at: " + towerSpots.transform.position);
            gameEvents.RaiseOnSpendCoins(towerSO.cost);
        }

    }

}

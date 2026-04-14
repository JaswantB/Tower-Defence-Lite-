using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    private TowerSpots selectedSpot;
    private TowerSO selectedTower;
    private bool isGameOver = false;

    private void OnEnable()
    {
        gameEvents.OnTowerSelected += SelectTower;
        gameEvents.OnGameOver += HandleGameOver;
        gameEvents.OnVictory += HandleVictory;
        gameEvents.OnPurchaseSuccess += HandlePurchaseSuccess;
    }
    private void OnDisable()
    {
        gameEvents.OnTowerSelected -= SelectTower;
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
            if (spot.isOccupied)
            {
                Debug.Log("Spot is already occupied!");
                return;
            }
            selectedSpot = spot;
            gameEvents.RaiseOnOpenTowerPanel();
        }

    }

    private void SelectTower(TowerSO towerSO)
    {
        if (selectedSpot == null)
        {
            Debug.LogWarning("No Tower Spot Selected");
            return;
        }
        selectedTower = towerSO;
        gameEvents.RaiseOnSpendCoins(towerSO.cost);
    }
    private void HandlePurchaseSuccess()
    {
        Debug.Log("Purchase successful!");
        if (selectedSpot == null || selectedTower == null)
        {
            Debug.Log("selectedSpot or selectedTower is null");
            return;
        }

        Instantiate(selectedTower.towerPrefab, selectedSpot.transform.position, Quaternion.identity);
        Debug.Log("Tower instantiated at: " + selectedSpot.transform.position);

        selectedSpot.OccupySpot(true);

        selectedSpot = null;
        selectedTower = null;
        gameEvents.RaiseOnCloseTowerPanel();
    }
}

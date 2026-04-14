using UnityEngine;
using UnityEngine.UI;

public class TowerButtonUI : MonoBehaviour
{
    [SerializeField] private TowerSO towerSO;
    [SerializeField] private GameEvents gameEvents;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            gameEvents.RaiseOnTowerSelected(towerSO);
        });
    }
}


using UnityEngine;

public class TowerPanelUI : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;

    private void Awake()
    {
        gameEvents.OnOpenTowerPanel += Show;
        gameEvents.OnCloseTowerPanel += Hide;
    }
    private void OnEnable()
    {
        gameEvents.OnOpenTowerPanel += Show;
        gameEvents.OnCloseTowerPanel += Hide;
    }

    private void OnDisable()
    {
        gameEvents.OnOpenTowerPanel -= Show;
        gameEvents.OnCloseTowerPanel -= Hide;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

}

using UnityEngine;

[CreateAssetMenu(menuName = "Game/Tower")]
public class TowerSO : ScriptableObject
{
  public float damage;
  public float range;
  public float fireRate;
  public int cost;
  public bool unlockShop;
  public GameObject towerPrefab;
  public GameObject projectilePrefab;
}

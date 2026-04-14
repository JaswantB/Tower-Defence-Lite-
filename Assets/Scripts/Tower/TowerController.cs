using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private TowerSO towerSO;

    private float timeBeforeShot;
    private float damageAmount;

    void Start()
    {
        float interval= 1f/towerSO.fireRate;
        InvokeRepeating("Shoot",0f,interval);
    }

    private void Shoot()
    {
        EnemyHealth targetEnemy = FindClosestEnemy();
        if (targetEnemy != null)
        {
            Debug.Log($"Tower {gameObject.name} shooting at {targetEnemy.gameObject.name}");
            targetEnemy.TakeDamage(towerSO.damage);
        }
    }
    private EnemyHealth FindClosestEnemy()
    {
        List<EnemyHealth> enemies = EnemyStats.GetAll();
        EnemyHealth nearestEnemy = null;
        float closestDist= towerSO.range;

        for(int i=0; i < enemies.Count; i++)
        {
            float distance=Vector3.Distance(transform.position, enemies[i].transform.position); //Calculate the distance between the tower and the enemy
            if(distance < closestDist)
            {
                closestDist = distance;
                nearestEnemy = enemies[i];
            }
        }
        return nearestEnemy;
    }


}

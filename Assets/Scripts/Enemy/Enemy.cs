using UnityEngine;

public class Enemy : MonoBehaviour
{
   private EnemyHealth enemyHealth;
   private EnemyWayPoint enemyWayPoint;
   private void Awake()
   {
       enemyHealth = GetComponent<EnemyHealth>();
       enemyWayPoint = GetComponent<EnemyWayPoint>();
   }
   public void Init(EnemySO enemySO, Transform[] waypoints)
   {
       enemyHealth.Init(enemySO);
       enemyWayPoint.WayPoint(waypoints, enemySO.moveSpeed);
   }
}

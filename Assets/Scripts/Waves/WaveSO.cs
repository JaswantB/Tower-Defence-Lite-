using UnityEngine;

[CreateAssetMenu(menuName = "Game/Wave")]
public class WaveSO : ScriptableObject
{
   [System.Serializable]
   public class EnemySpawn
    {
        public EnemySO enemySO;
        public int spawnCount;
        public float spawnDelay;
     }
     public List<EnemySpawn> enemySpawns;
     public float timeBetweenWaves;
    
}

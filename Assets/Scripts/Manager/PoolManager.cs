using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]private List<Pooling>poolings;
    [SerializeField]private List<EnemySO> enemyTypes;

    public GameObject GetEnemy(EnemySO enemySO)
    {
        for(int i = 0; i < enemyTypes.Count; i++)
        {
            if (enemyTypes[i] == enemySO)
            {
                return poolings[i].GetEnemy();
            }
        }
        return null;
    }

}

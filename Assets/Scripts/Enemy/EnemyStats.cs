using System.Collections.Generic;
using UnityEngine;

public static class EnemyStats
{
    private static List<EnemyHealth>activeEnemy=new List<EnemyHealth>();

    public static void RegisterHealth(EnemyHealth enemy)
    {
        activeEnemy.Add(enemy);
    }
    public static void UnRegisterHealth(EnemyHealth enemy)
    {
        activeEnemy.Remove(enemy);
    }
    public static List<EnemyHealth> GetAll()
    {
        return activeEnemy;
    }
}

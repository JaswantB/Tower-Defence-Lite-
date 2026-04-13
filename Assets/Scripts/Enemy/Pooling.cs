using System.Collections.Generic;
using UnityEngine;
public class Pooling : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int poolSize = 20;
   [SerializeField]private Transform enemyParent;
    private List<GameObject> enemies = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyParent);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].activeInHierarchy == false)
            {
                enemies[i].SetActive(true);
                return enemies[i];
            }
        }
        GameObject newEnemy=Instantiate(enemyPrefab, enemyParent);
        enemies.Add(newEnemy);
        return newEnemy;
    }
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }

}

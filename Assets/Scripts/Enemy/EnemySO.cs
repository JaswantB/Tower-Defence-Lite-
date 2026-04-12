using UnityEngine;

[CreateAssetMenu(menuName = "Game/Enemy")]
public class EnemySO : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public int damageAmount;
    public int reward;

    public GameObject prefab;
    
}

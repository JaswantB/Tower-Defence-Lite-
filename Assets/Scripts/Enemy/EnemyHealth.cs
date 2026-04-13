using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private GameEvents gameEvents;
    [SerializeField]private Pooling enemyPool;

    private float maxHealth;
    private float currentHealth;
    private int rewardAmt;

    private void OEnable()
    {
        EnemyStats.RegisterHealth(this);
    }
    private void OnDisable()
    {
        EnemyStats.UnRegisterHealth(this);
    }
    public void EnemyStatus(EnemySO enemySO)
    {
        maxHealth=enemySO.maxHealth;
        currentHealth=enemySO.maxHealth;
        rewardAmt=enemySO.reward;
    }

}

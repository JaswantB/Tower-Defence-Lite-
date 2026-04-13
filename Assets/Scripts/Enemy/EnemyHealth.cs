using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;

    private float maxHealth;
    private float currentHealth;
    private int rewardAmt;

    private void OnEnable()
    {
        EnemyStats.RegisterHealth(this);
    }
    private void OnDisable()
    {
        EnemyStats.UnRegisterHealth(this);
    }
    private void EnemyStatus(EnemySO enemySO)
    {
        maxHealth = enemySO.maxHealth;
        currentHealth = enemySO.maxHealth;
        rewardAmt = enemySO.reward;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameEvents.RaiseOnCoinChanged(rewardAmt);
        gameObject.SetActive(false);
    }

}

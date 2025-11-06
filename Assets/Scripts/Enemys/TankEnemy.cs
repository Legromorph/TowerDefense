using UnityEngine;

public class TankEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        normalSpeed = normalSpeed * 2.5f;
        maxHealth = Mathf.RoundToInt(maxHealth * 2.5f);
        currentHealth = maxHealth;
    }


    protected override void Die()
    {
        base.Die();
        
    }
}

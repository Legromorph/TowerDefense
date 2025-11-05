using UnityEngine;

public class TankEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        speed = 1.2f;
        maxHealth = 10;
        currentHealth = maxHealth;
    }


    protected override void Die()
    {
        base.Die();
        
    }
}

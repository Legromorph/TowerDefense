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


    protected virtual void Die()
    {
        base.Die()
        
    }
}

using UnityEngine;

public class FastEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        speed = 5f;
        maxHealth = 3;
        currentHealth = maxHealth;
    }
}

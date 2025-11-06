using UnityEngine;

public class FastEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        currentSpeed = normalSpeed * 1.7f;
        maxHealth = Mathf.RoundToInt(maxHealth * 0.7f);
        currentHealth = maxHealth;
    }
}

using UnityEngine;

public class TankEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        NormalSpeed = NormalSpeed * 2.5f;
        MaxHealth = Mathf.RoundToInt(MaxHealth * 2.5f);
        CurrentHealth = MaxHealth;
    }


    protected override void Die()
    {
        base.Die();
        
    }
}

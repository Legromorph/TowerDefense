using UnityEngine;

public class FastEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        NormalSpeed = NormalSpeed * 1.7f;
        CurrentSpeed = NormalSpeed;
        MaxHealth = Mathf.RoundToInt(MaxHealth * 0.7f);
        CurrentHealth = MaxHealth;
    }
}

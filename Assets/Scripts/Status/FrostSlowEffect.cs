public class FrostSlowEffect : StatusEffect
{
    private float slowFactor;

    public FrostSlowEffect(EnemyBase enemy, float duration, float slowFactor)
        : base(enemy, duration)
    {
        this.name = "FrostSlow";
        this.slowFactor = slowFactor;
    }

    public override void ApplyEffect()
    {
        enemy.currentSpeed *= slowFactor;
    }

    public override void RemoveEffect()
    {
        enemy.currentSpeed /= slowFactor;
    }
}
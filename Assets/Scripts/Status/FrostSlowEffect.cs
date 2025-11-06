public class FrostSlowEffect : StatusEffect
{
    private float slowFactor;

    public FrostSlowEffect(EnemyBase enemy, float duration, float slowFactor) : base(enemy, duration, true)
    {
        this.Name = "FrostSlow";
        this.slowFactor = slowFactor;
    }


    public override void ApplyEffect()
    {
        Enemy.AddSpeedModifier(slowFactor);
    }

    public override void RemoveEffect()
    {
        Enemy.RemoveSpeedModifier(slowFactor);
    }

    public override void AddStack()
    {
        base.AddStack();
        Duration = 1f;
    }
}
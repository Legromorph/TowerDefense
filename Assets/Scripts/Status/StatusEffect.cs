public abstract class StatusEffect
{
    public string name;
    public float duration;
    protected EnemyBase enemy;

    public StatusEffect(EnemyBase enemy, float duration)
    {
        this.enemy = enemy;
        this.duration = duration;
    }

    public virtual void ApplyEffect() { }
    public virtual void RemoveEffect() { }
    public virtual void UpdateEffect(float deltaTime)
    {
        duration -= deltaTime;
    }

    public bool IsExpired => duration <= 0;
}
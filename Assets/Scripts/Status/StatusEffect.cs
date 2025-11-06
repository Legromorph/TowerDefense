public abstract class StatusEffect
{
    public string Name { get; protected set; }
    public float Duration { get; protected set; }
    public bool IsStackable { get; private set; }
    public EnemyBase Enemy { get; protected set; } 
    protected int stackCount = 1;

    public StatusEffect(EnemyBase enemy, float duration, bool isStackable = false)
    {
        this.Enemy = enemy;
        this.Duration = duration;
        IsStackable = isStackable;
    }

    public virtual void ApplyEffect() { }
    public virtual void RemoveEffect() { }
    public virtual void UpdateEffect(float deltaTime)
    {
        Duration -= deltaTime;
    }

    public virtual void AddStack()
    {
        stackCount++;
    }

    public bool IsExpired => Duration <= 0;
}
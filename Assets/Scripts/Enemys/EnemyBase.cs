using UnityEngine;
using System.Collections.Generic;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float normalSpeed = 2f;
    [SerializeField] private int maxHealth = 5;

    [SerializeField] private float currentSpeed;
    [SerializeField] private int currentHealth;

    public float NormalSpeed { get => normalSpeed; protected set => normalSpeed = value; }
    public int MaxHealth { get => maxHealth; protected set => maxHealth = value; }
    public float CurrentSpeed { get => currentSpeed; protected set => currentSpeed = value; }
    public int CurrentHealth { get => currentHealth; protected set => currentHealth = value; }


    private readonly List<float> speedModifiers = new List<float>();

    [Header("Path")]
    [SerializeField] protected Transform[] waypoints;
    protected int waypointIndex = 0;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        currentSpeed = normalSpeed;
    }

    protected virtual void Update()
    {
        MoveAlongPath();
    }

    public virtual void Initialize(Transform[] _waypoints)
    {
        waypoints = _waypoints;
    }

    protected void MoveAlongPath()
    {
        if (waypoints == null || waypointIndex >= waypoints.Length) return;

        Transform target = waypoints[waypointIndex];
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * GetEffectiveSpeed() * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                ReachGoal();
            }
        }
    }

    public virtual void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
            Die();
    }

    protected virtual void ReachGoal() => Destroy(gameObject);
    protected virtual void Die() => Destroy(gameObject);

    // ---- SPEED SYSTEM ----

    public float GetEffectiveSpeed()
    {
        float totalFactor = 1f;
        foreach (float mod in speedModifiers)
            totalFactor *= mod;
        return normalSpeed * totalFactor;
    }

    public void AddSpeedModifier(float factor) => speedModifiers.Add(factor);
    public void RemoveSpeedModifier(float factor) => speedModifiers.Remove(factor);
    public void ResetSpeedModifiers() => speedModifiers.Clear();
}

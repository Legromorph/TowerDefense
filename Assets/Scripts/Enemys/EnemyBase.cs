using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float normalSpeed = 2f;
    public float currentSpeed;
    public int maxHealth = 5;
    protected int currentHealth;
    [Header("Path")]
    [SerializeField]
    protected Transform[] waypoints;
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
        transform.Translate(dir.normalized * currentSpeed * Time.deltaTime, Space.World);

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
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    protected virtual void ReachGoal()
    {
        Destroy(gameObject);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void ChangeSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public virtual float GetNormalSpeed()
    {
        return normalSpeed;
    }

    public virtual float GetCurrentSpeed()
    {
        return currentSpeed;
    }

}

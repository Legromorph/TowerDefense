using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [Header("Tower Stats")]
    public float range = 5f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    protected float fireCountdown = 0f;
    protected Transform target;

    protected virtual void Update()
    {
        FindTarget();
        if (target == null) return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    protected virtual void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else
            target = null;
    }

    protected abstract void Shoot();
}
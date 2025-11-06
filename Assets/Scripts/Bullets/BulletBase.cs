using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected Transform target;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected int damage;

    public virtual void Initialize(Transform _target, int _damage)
    {
        target = _target;
        damage = _damage;
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    protected virtual void HitTarget()
    {
        EnemyBase e = target.GetComponent<EnemyBase>();
        if (e != null)
            e.TakeDamage(damage);

        Destroy(gameObject);
    }
}

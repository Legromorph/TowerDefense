using UnityEngine;
using System.Collections;

public class FrostBullet : BulletBase
{
    private float slowFactor;
    private float slowDuration;

    public void Initialize(Transform _target, int _damage, float _slowFactor, float _slowDuration)
    {
        base.Initialize(_target, _damage);
        slowFactor = _slowFactor;
        slowDuration = _slowDuration;
    }

    protected override void HitTarget()
    {
        EnemyBase e = target.GetComponent<EnemyBase>();
        StatusController sc = e.GetComponent<StatusController>();
        if (e != null)
        {
            e.TakeDamage(damage);
            if (sc != null)
            {
                sc.AddEffect(new FrostSlowEffect(e, slowDuration, slowFactor));
            }
        }

        Destroy(gameObject);
    }

}

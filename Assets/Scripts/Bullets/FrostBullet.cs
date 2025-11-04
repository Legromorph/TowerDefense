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
        if (e != null)
        {
            e.TakeDamage(damage);
            e.StartCoroutine(SlowEffect(e));
        }

        Destroy(gameObject);
    }

    private IEnumerator SlowEffect(EnemyBase enemy)
    {
        float originalSpeed = enemy.speed;
        enemy.ChangeSpeed(originalSpeed * slowFactor);
        yield return new WaitForSeconds(slowDuration);
        enemy.ChangeSpeed(originalSpeed);
    }
}

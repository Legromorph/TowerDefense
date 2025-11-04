using UnityEngine;

public class CannonTower : TowerBase
{
    protected override void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletBase bullet = bulletGO.GetComponent<BulletBase>();
        bullet.Initialize(target, 3); // Schaden = 3
    }
}

using UnityEngine;

public class FrostTower : TowerBase
{
    protected override void Shoot()
    {
        Debug.Log("Shoot() called");
        Debug.Log("bulletPrefab: " + bulletPrefab);
        Debug.Log("firePoint: " + firePoint);
        Debug.Log("target: " + target);
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FrostBullet bullet = bulletGO.GetComponent<FrostBullet>();
        bullet.Initialize(target, 1, 0.5f, 2f); // Schaden, SlowFactor, Dauer
    }
}

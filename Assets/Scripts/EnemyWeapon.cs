using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    [SerializeField] private float fireRate = 1f;

    public IEnumerator ShootContinuously()
    {
        WaitForSeconds delay = new WaitForSeconds(fireRate);

        while (true)
        {
            Shoot();
            yield return delay;
        }
    }

    public void SetBulletPool(ObjectPool pool)
    {
        BulletPool = pool;
    }
}

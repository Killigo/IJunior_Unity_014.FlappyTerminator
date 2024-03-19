using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    [SerializeField] private float initialShootDelay = 2f;
    [SerializeField] private float fireRate = 1f;

    private void Start()
    {
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(initialShootDelay);

        StartCoroutine(ShootContinuously());
    }

    IEnumerator ShootContinuously()
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

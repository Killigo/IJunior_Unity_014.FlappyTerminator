using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float initialShootDelay = 2f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private Transform _shootPoint;

    protected ObjectPool BulletPool;

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

    private void Shoot()
    {
        GameObject bullet = BulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
    }

    public void SetBulletPool(ObjectPool pool)
    {
        BulletPool = pool;
    }
}

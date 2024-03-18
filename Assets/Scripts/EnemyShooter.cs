using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking.Types;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float initialShootDelay = 2f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private Transform _shootPoint;

    private ObjectPool _bulletPool;

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
        GameObject bullet = _bulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
        bullet.GetComponent<EnemyBullet>().Died += OnDied;
    }

    private void OnDied()
    {
        _bulletPool.PutObject(gameObject);
    }

    public void SetBulletPool(ObjectPool pool)
    {
        _bulletPool = pool;
    }
}

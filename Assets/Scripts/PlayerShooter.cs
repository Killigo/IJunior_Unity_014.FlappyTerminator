using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private KeyCode _shoot = KeyCode.Mouse0;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ObjectPool _bulletPool;

    private void Update()
    {
        if (Input.GetKeyDown(_shoot))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = _bulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
    }
}

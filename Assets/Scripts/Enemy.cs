using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ObjectPool _enemyPool;

    private void Start()
    {
        _enemyPool = GetComponentInParent<ObjectPool>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBullet bullet))
        {
            Die();
        }
    }

    public void Die()
    {
        _enemyPool.PutObject(gameObject);
    }
}

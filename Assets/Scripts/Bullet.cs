using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed = 5f;

    public event Action<GameObject> Destroyed;

    //private ObjectPool _bulletPool;

    //private void Start()
    //{
    //    _bulletPool = GetComponentInParent<ObjectPool>();
    //}

    private void Update()
    {
        Move();
    }

    private void OnBecameInvisible()
    {
        Destroyed?.Invoke(gameObject);
        //_bulletPool.PutObject(gameObject);
    }

    protected abstract void Move();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Destroyed?.Invoke(gameObject);
            //_bulletPool.PutObject(gameObject);
        }
    }
}

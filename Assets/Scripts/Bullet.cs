using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed = 5f;

    private ObjectPool _bulletPool;

    private void Start()
    {
        _bulletPool = GetComponentInParent<ObjectPool>();
    }

    private void Update()
    {
        Move();
    }

    private void OnBecameInvisible()
    {
        _bulletPool.PutObject(gameObject);
    }

    protected abstract void Move();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            _bulletPool.PutObject(gameObject);
        }
    }
}

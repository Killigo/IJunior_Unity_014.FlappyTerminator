using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed = 5f;

    private ObjectPool _pool;

    private void Start()
    {
        _pool = GetComponentInParent<ObjectPool>();
    }

    private void Update()
    {
        Move();
    }

    public void OnBecameInvisible()
    {
        _pool.PutObject(gameObject);
    }

    protected abstract void Move();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _pool.PutObject(gameObject);
    }
}

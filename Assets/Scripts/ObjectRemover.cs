using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name + "OnTriggerEnter2D");

        if (collider.TryGetComponent(out Bullet poolObject))
        {
            _pool.PutObject(poolObject.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "OnCollisionEnter2D");

        if (collision.gameObject.TryGetComponent(out Bullet poolObject))
        {
            _pool.PutObject(poolObject.gameObject);
        }
    }
}
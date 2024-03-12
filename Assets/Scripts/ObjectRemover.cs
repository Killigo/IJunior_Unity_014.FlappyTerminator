using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("target");

        if (collider.TryGetComponent(out Bullet poolObject))
        {
            Debug.Log(poolObject.gameObject.name);
            _pool.PutObject(poolObject.gameObject);
        }
    }
}
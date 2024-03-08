using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out GameObject poolObject))
        {
            Debug.Log(poolObject.gameObject.name);
            _pool.PutObject(poolObject);
        }
    }
}
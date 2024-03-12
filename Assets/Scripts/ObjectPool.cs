using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private Queue<GameObject> _pool;

    public IEnumerable<GameObject> PooledObject => _pool;

    private void Awake()
    {
        _pool = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            GameObject poolObject = Instantiate(_prefab);
            poolObject.transform.parent = transform;

            return poolObject;
        }

        GameObject returnObject = _pool.Dequeue();
        returnObject.SetActive(true);

        return returnObject;
    }

    public void PutObject(GameObject poolObject)
    {
        _pool.Enqueue(poolObject);
        poolObject.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}

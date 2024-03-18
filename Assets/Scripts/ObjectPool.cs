using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected Transform container;
    [SerializeField] protected GameObject prefab;

    protected Queue<GameObject> pool;

    public IEnumerable<GameObject> PooledObject => pool;

    private void Awake()
    {
        pool = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            GameObject poolObject = Instantiate(prefab);
            poolObject.transform.parent = container;

            return poolObject;
        }

        GameObject returnObject = pool.Dequeue();
        returnObject.SetActive(true);

        return returnObject;
    }

    public void PutObject(GameObject poolObject)
    {
        pool.Enqueue(poolObject);
        poolObject.SetActive(false);
    }

    public void Reset()
    {
        pool.Clear();
    }
}

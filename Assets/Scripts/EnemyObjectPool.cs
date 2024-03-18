using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : ObjectPool
{
    public GameObject GetObject(ObjectPool _bulletPool)
    {
        if (pool.Count == 0)
        {
            GameObject poolObject = Instantiate(prefab);
            poolObject.transform.parent = container;

            EnemyShooter enemyShooter = poolObject.GetComponent<EnemyShooter>();
            enemyShooter.SetBulletPool(_bulletPool);

            return poolObject;
        }

        GameObject returnObject = pool.Dequeue();
        returnObject.SetActive(true);

        return returnObject;
    }
}

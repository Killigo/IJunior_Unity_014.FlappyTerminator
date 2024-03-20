using UnityEngine;

public class EnemyObjectPool : ObjectPool
{
    public GameObject GetObject(ObjectPool bulletPool)
    {
        if (pool.Count == 0)
        {
            GameObject poolObject = Instantiate(prefab);
            poolObject.transform.parent = container;

            EnemyWeapon weapon = poolObject.GetComponent<EnemyWeapon>();
            weapon.SetBulletPool(bulletPool);

            return poolObject;
        }

        GameObject returnObject = pool.Dequeue();
        returnObject.SetActive(true);

        return returnObject;
    }
}

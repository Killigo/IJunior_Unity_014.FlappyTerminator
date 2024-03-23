using UnityEngine;

public class EnemyObjectPool : ObjectPool
{
    public GameObject GetObject(ObjectPool bulletPool)
    {
        if (Pool.Count == 0)
        {
            GameObject poolObject = Instantiate(Prefab);
            poolObject.transform.parent = Container;

            EnemyWeapon weapon = poolObject.GetComponent<EnemyWeapon>();
            weapon.SetBulletPool(bulletPool);

            return poolObject;
        }

        GameObject returnObject = Pool.Dequeue();
        returnObject.SetActive(true);

        return returnObject;
    }
}

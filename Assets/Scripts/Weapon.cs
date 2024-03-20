using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;

    protected ObjectPool BulletPool;

    protected void Shoot()
    {
        GameObject bullet = BulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
        bullet.GetComponent<Bullet>().Destroyed += OnDestroyed; // ãäå îòïèñûâàòüñÿ?
    }
/*
    protected void Shoot()
    {
        GameObject bullet = BulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.Destroyed += OnDestroyed;
    }*/

    private void OnDestroyed(GameObject gameObject)
    {
        BulletPool.PutObject(gameObject);
    }
/*
    private void OnDestroyed(GameObject gameObject)
    {
        Bullet bulletComponent = gameObject.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.Destroyed -= OnDestroyed;
        }
        BulletPool.PutObject(gameObject);
    }*/
}

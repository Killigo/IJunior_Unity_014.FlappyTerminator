using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;

    protected ObjectPool BulletPool;

    protected void Shoot()
    {
        GameObject bullet = BulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
        bullet.GetComponent<Bullet>().Destroyed += OnDestroyed;
    }

    private void OnDestroyed(GameObject gameObject)
    {
        Bullet bullet = gameObject.GetComponent<Bullet>();
        bullet.Destroyed -= OnDestroyed;
        BulletPool.PutObject(gameObject);
    }
}

using UnityEngine;

public abstract class CharacterShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected ObjectPool _bulletPool;

    protected void Shoot()
    {
        GameObject bullet = _bulletPool.GetObject();
        bullet.transform.position = _shootPoint.position;
    }
}

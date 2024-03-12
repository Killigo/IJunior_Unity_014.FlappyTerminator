using UnityEngine;

public abstract class CharacterShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ObjectPool _pool;

    protected void Shoot()
    {
        GameObject bullet = _pool.GetObject();
        bullet.transform.position = _shootPoint.position;
    }
}

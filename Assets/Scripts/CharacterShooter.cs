using UnityEngine;

public class CharacterShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ObjectPool _pool;

    protected void Shoot()
    {
        GameObject bullet = _pool.GetObject();
        bullet.transform.position = _shootPoint.position;
    }
}

using UnityEngine;

public class PlayerWeapon : Weapon
{
    [SerializeField] private KeyCode _shoot = KeyCode.Mouse0;
    [SerializeField] private ObjectPool _bulletPool;

    private void Start()
    {
        BulletPool = _bulletPool;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_shoot))
            Shoot();
    }
}

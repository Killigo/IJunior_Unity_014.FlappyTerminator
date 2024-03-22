using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void Move()
    {
        transform.Translate(-transform.right * Speed * Time.deltaTime);
    }
}

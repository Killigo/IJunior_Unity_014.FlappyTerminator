using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Move()
    {
        transform.Translate(transform.right * Speed * Time.deltaTime);
    }
}

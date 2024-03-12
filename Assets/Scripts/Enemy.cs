using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + " OnTriggerEnter2D");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Debug.Log(gameObject.name + " die");
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

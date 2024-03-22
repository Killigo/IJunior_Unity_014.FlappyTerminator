using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyWeapon))]
public class Enemy : MonoBehaviour, IDead
{
    [SerializeField] private float initialShootDelay = 2f;

    private EnemyWeapon _weapon;
    private Coroutine _shootCoroutine;

    public event Action<GameObject> Died;

    private void Start()
    {
        _weapon = GetComponent<EnemyWeapon>();
    }

    private void OnEnable()
    {
        _shootCoroutine = StartCoroutine(StartShooting());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBullet bullet))
        {
            Die();
        }
    }

    private IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(initialShootDelay);

        StartCoroutine(_weapon.ShootContinuously());
    }

    public void Die()
    {
        StopCoroutine(_shootCoroutine);
        Died?.Invoke(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _maxSpawnPositionY;
    [SerializeField] private int _minSpawnPositionY;
    [SerializeField] private EnemyObjectPool _enemyPool;
    [SerializeField] private ObjectPool _enemyBulletPool;
    [SerializeField] private float _spawnDelay = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemyContinuously());
    }

    IEnumerator SpawnEnemyContinuously()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            Spawn();
            yield return delay;
        }
    }

    private void Spawn()
    {
        GameObject enemyObject = _enemyPool.GetObject(_enemyBulletPool);
        enemyObject.transform.position = new Vector2(transform.position.x, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
        /*
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.Died += OnDied;
        
        EnemyShooter enemyShooter = enemyObject.GetComponent<EnemyShooter>();
        enemyShooter.SetBulletPool(_enemyBulletPool);*/
    }
}

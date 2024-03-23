using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int _upperBound;
    [SerializeField] private int _lowerBound;
    [SerializeField] private EnemyObjectPool _enemyPool;
    [SerializeField] private ObjectPool _enemyBulletPool;
    [SerializeField] private float _spawnDelay = 3f;

    [SerializeField] private ScoreCounter _scoreCounter;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemyContinuously());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnEnemyContinuously()
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
        GameObject enemy = _enemyPool.GetObject(_enemyBulletPool);
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        enemy.transform.position = new Vector2(transform.position.x, spawnPositionY);

        enemy.GetComponent<Enemy>().Died += OnDied;
    }

    private void OnDied(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Died -= OnDied;
        _scoreCounter.Add();
        _enemyPool.PutObject(enemy);
    }
}

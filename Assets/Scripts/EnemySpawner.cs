using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _maxSpawnPositionY;
    [SerializeField] private int _minSpawnPositionY;
    [SerializeField] private ObjectPool _enemyPool;
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
        GameObject enemy = _enemyPool.GetObject();
        enemy.transform.position = new Vector2(transform.position.x, Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
    }
}

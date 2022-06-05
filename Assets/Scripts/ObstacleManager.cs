using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;

    private List<GameObject> _obstacles = new List<GameObject>();
    private bool _canSpawn;
    private float _timeToNextSpawn;

    private void Awake()
    {
        CalculateTimeToNextSpawn();
    }

    private void Update()
    {
        if (_canSpawn)
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (_timeToNextSpawn < 0)
            {
                CalculateTimeToNextSpawn();
                // Spawn obstacle
                _obstacles.Add(Instantiate(_obstaclePrefab,
                                             _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
                                             Quaternion.identity));
            }
        }
    }

    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    public void DestroyProjectiles()
    {
        foreach (var projectile in _obstacles)
        {
            Destroy(projectile);
        }

        _canSpawn = false;
    }

    public void StartSpawning()
    {
        _canSpawn = true;
    }
}

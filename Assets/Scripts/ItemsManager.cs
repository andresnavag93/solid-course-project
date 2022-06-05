using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsManager : MonoBehaviour
{
    public enum ItemTypes
    {
        PermanentSpeed,
        Heal
    }
    [SerializeField] private SpeedItem _speedItem;
    [SerializeField] private HealItem _healItem;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;
    
    private List<GameObject> _items = new List<GameObject>();
    private bool _canSpawn;
    private float _timeToNextSpawn;

    private void Start()
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
                // Get random item to spawn
                SpawnItem((ItemTypes) Random.Range(0, Enum.GetNames(typeof(ItemTypes)).Length));
            }
        }
    }
    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnItem(ItemTypes type)
    {
        // Spawn the items in random position
        switch (type)
        {
            case ItemTypes.PermanentSpeed:
                _items.Add(Instantiate(_speedItem,
                                       _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
                                       Quaternion.identity).gameObject);
                break;
            case ItemTypes.Heal:
                _items.Add(Instantiate(_healItem,
                                       _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
                                       Quaternion.identity).gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
    
    public void DestroyItems()
    {
        foreach (var projectile in _items)
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

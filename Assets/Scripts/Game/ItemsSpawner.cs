using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private string[] _itemsIds;

    [SerializeField] private AbstractItem[] _prefabItems;
    private Dictionary<string, AbstractItem> _idToItemPrefabs;

    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;

    private List<GameObject> _spawnedItems = new List<GameObject>();
    private bool _isSpawnAvailable;
    private float _timeToNextSpawn;

    private void Awake()
    {
        _idToItemPrefabs = new Dictionary<string, AbstractItem>();
        foreach (var prefabItem in _prefabItems)
        {
            _idToItemPrefabs.Add(prefabItem.Id, prefabItem);
        }
    }

    private void Start()
    {
        CalculateTimeToNextSpawn();
    }

    private void Update()
    {
        if (_isSpawnAvailable)
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (_timeToNextSpawn < 0)
            {
                CalculateTimeToNextSpawn();
                // Get random item to spawn
                SpawnItem(_itemsIds[Random.Range(0, _itemsIds.Length)]);
            }
        }
    }
    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnItem(string id)
    {
        // Spawn the items in random position
        AbstractItem itemToInstantiate;
        if (!_idToItemPrefabs.TryGetValue(id, out itemToInstantiate))
        {
            throw new ArgumentOutOfRangeException();
        }
        _spawnedItems.Add(Instantiate(itemToInstantiate,
            _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
            Quaternion.identity).gameObject);
    }

    public void DestroyItems()
    {
        foreach (var projectile in _spawnedItems)
        {
            Destroy(projectile);
        }

        _isSpawnAvailable = false;
    }

    public void StartSpawning()
    {
        _isSpawnAvailable = true;
    }
}

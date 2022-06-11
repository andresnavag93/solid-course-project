﻿using UnityEngine;

/* Manage the state of the game */
public class GameEventListener : MonoBehaviour
{
    public static GameEventListener Instance { get; private set; }

    [SerializeField] private MainMenu _menu;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private ItemsSpawner _itemSpawner;
    [SerializeField] private Player _player;

    private float _gameStartTime;

    private ISaver _save;

    private void Awake()
    {
        Instance = this;
    }

    public void Configure(ISaver save)
    {
        _save = save;
    }

    public void OnPlayerDeath()
    {
        _obstacleSpawner.DestroyProjectiles();
        _itemSpawner.DestroyItems();
        var gameDuration = Time.time - _gameStartTime;
        // Save the last duration
        _save.SaveData(gameDuration);
        _menu.ShowGameOver();
    }

    public void OnStartGame()
    {
        // Start timer
        _gameStartTime = Time.time;
        // Start the logic of the managers and reset the player
        _obstacleSpawner.StartSpawning();
        _itemSpawner.StartSpawning();
        _player.Reset();
    }
}

using UnityEngine;

/* Manage the state of the game */
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Menu _menu;
    [SerializeField] private ObstacleManager _obstacleManager;
    [SerializeField] private ItemsManager _itemsManager;
    [SerializeField] private Player _player;

    private float _startTime;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPlayerDeath()
    {
        _obstacleManager.DestroyProjectiles();
        _itemsManager.DestroyItems();
        var duration = Time.time - _startTime;
        // Save the last duration
        PlayerPrefs.SetFloat("duration", duration);
        PlayerPrefs.Save();
        _menu.ShowGameOver();
    }

    public void OnStartGame()
    {
        // Start timer
        _startTime = Time.time;
        // Start the logic of the managers and reset the player
        _obstacleManager.StartSpawning();
        _itemsManager.StartSpawning();
        _player.Reset();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
/* Start game menu */
public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _lastDuration;

    private ILoad _load;
    private void Awake()
    {
        _load = new Persistence();
        _startButton.onClick.AddListener(OnStartButtonPressed);
    }

    private void OnEnable()
    {
        // Get the last time and format it
        var time = TimeSpan.FromSeconds(_load.LoadLastDuration());
        _lastDuration.text = time.ToString(@"mm\:ss");
    }

    private void OnStartButtonPressed()
    {
        GameManager.Instance.OnStartGame();
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }
}

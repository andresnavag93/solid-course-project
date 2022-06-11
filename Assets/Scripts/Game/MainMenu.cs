using System;
using UnityEngine;
using UnityEngine.UI;
/* Start game menu */
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _lastGameDurationText;

    private ILoader _load;
    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartButtonPressed);
    }

    public void Configure(ILoader load)
    {
        _load = load;
    }

    private void OnEnable()
    {
        // Get the last time and format it
        var time = TimeSpan.FromSeconds(_load.LoadData());
        _lastGameDurationText.text = time.ToString(@"mm\:ss");
    }

    private void OnStartButtonPressed()
    {
        GameEventListener.Instance.OnStartGame();
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }
}

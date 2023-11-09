using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _counter;
    private PlayerEvents _playerEvents;

    public delegate void CounterHandler(int counter);
    public event CounterHandler Counted;

    public delegate void GameHandler();
    public event GameHandler GameFinished;

    private enum Level {Zero, One, Two};
    private Level _level;
    
    void Awake()
    {
        _counter = 0;
        _playerEvents = GameObject.Find("Player").GetComponent<PlayerEvents>();
        _level = (Level)SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _playerEvents.PowerUpPicked += OnPowerUpPicked;
    }

    private void OnDisable()
    {
        _playerEvents.PowerUpPicked -= OnPowerUpPicked;
    }

    void OnPowerUpPicked()
    {
        _counter++;
        Counted?.Invoke(_counter);
        LevelFinished(_level);
    }

    void LevelFinished(Level level)
    {        
        switch (level)
        {
            case Level.One:
                if (_counter == 3) GameFinished?.Invoke();
                break;
            case Level.Two:
                break;
            default:
                break;
        }
    }
}

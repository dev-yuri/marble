using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _counter;
    private Player _player;

    public delegate void CounterHandler(int counter);
    public event CounterHandler Counted;

    public delegate void GameHandler();
    public event GameHandler GameFinished;

    private enum Level {Zero, One, Two};
    private Level _level;
    
    void Awake()
    {
        _counter = 0;
        _player = GameObject.Find("Player").GetComponent<Player>();
        _level = (Level)SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _player.PowerUpPicked += OnPowerUpPicked;
    }

    private void OnDisable()
    {
        _player.PowerUpPicked -= OnPowerUpPicked;
    }

    // Update is called once per frame

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

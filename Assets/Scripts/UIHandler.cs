using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    
    private TextMeshProUGUI _score;
    private TextMeshProUGUI _timer;
    private int _counter;

    private float _sec;
    private int _min;
    private Animator _animator;

    private Player _player;


    // Start is called before the first frame update
    void Start()
    {
        
        _player = GameObject.Find("Player").GetComponent<Player>();
        _player.PowerUpPicked += OnItemsCollected;

        _score = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        _timer = transform.Find("Timer").GetComponent<TextMeshProUGUI>();
        _animator = transform.Find("Image").GetComponent<Animator>();
        _counter = 0;
        _sec = 0;
        _min = 0;
    }

    void Update()
    {
        DisplayTime();
    }

    private void OnDestroy()
    {
        _player.PowerUpPicked -= OnItemsCollected;
    }

    private void OnDisable()
    {
       _player.PowerUpPicked -= OnItemsCollected;
    }

    private void OnItemsCollected()
    {
        _counter++;
        _score.text = _counter + "/3";
        _animator.SetTrigger("Pulse");
    }

    private void DisplayTime()
    {
        _sec += Time.deltaTime;        
        if (_sec >= 60)
        {
            _min += 1;
            _sec = 0f;
        }

        _timer.text = _min.ToString("00") + "'" + _sec.ToString("00") + "''";
    }
}

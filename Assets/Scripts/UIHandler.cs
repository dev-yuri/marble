using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{    
    private TextMeshProUGUI _score;
    private TextMeshProUGUI _timer;
    private float _sec;
    private int _min;
    private Animator _animator;
    private GameManager _gameManager;
    private Transform _finished;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _finishedAudio;



    // Start is called before the first frame update
    void Awake()
    {
        _score = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        _timer = transform.Find("Timer").GetComponent<TextMeshProUGUI>();
        _animator = transform.Find("PowerUp").GetComponent<Animator>();
        
        _finished = transform.Find("LevelFinished").GetComponent<Transform>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();       
        
        _sec = 0;
        _min = 0;

    }

    private void Start()
    {
        _finished.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _gameManager.Counted += OnItemsCollected;
        _gameManager.GameFinished += LevelFinished;
    }

    private void OnDisable()
    {
        _gameManager.Counted -= OnItemsCollected;
        _gameManager.GameFinished -= LevelFinished;
    }

    void Update()
    {
        DisplayTime();
    }

    private void OnItemsCollected(int counter)
    {       
        _score.text = counter + "/3";
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

    private void LevelFinished()
    {
        _finished.gameObject.SetActive(true);
        _audioSource.PlayOneShot(_finishedAudio);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToNextLevel()
    {
        Debug.Log("Sorry, there is no more levels, yet ...");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

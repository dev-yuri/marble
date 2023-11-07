using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    PlayerMovementStateMachine movementStateMachine;

    public PlayerInput Input {get; private set;}
    public Rigidbody Rigidbody {get; private set;}

    // move to another script --> player events
    public delegate void PowerUpHandler();
    public event PowerUpHandler PowerUpPicked;

    // move to another scripts --> player SFX
    [SerializeField] private AudioClip _bounceAudio;
    [SerializeField] private AudioClip _marbleAudio;
    private AudioSource _audioSource;

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Rigidbody = GetComponent<Rigidbody>();

        movementStateMachine = new PlayerMovementStateMachine(this);

        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void Update()
    {
        movementStateMachine.HandleInput();
        movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
            PowerUpPicked?.Invoke();
    }

    void OnCollisionEnter(Collision other)
    {
        if (Rigidbody.velocity.magnitude > 0)
        {
            if (other.gameObject.CompareTag("Bed"))
                _audioSource.PlayOneShot(_bounceAudio, 1f);
            else
                _audioSource.PlayOneShot(_marbleAudio, Rigidbody.velocity.magnitude * .75f);
        }
    }
    
}
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _focalPoint;
    private AudioSource _audioSource;

    private float _verticalInput;
    private float _horizontalInput;
    [SerializeField] private AudioClip _bounceAudio;
    [SerializeField] private AudioClip _marbleAudio;
    [SerializeField] private float _moveForce;
    private float _jumpForce;
    private bool _isOnGround;

    public delegate void PowerUpHandler();
    public event PowerUpHandler PowerUpPicked;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Camera").GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
        _moveForce = 2f;
        _jumpForce = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(_focalPoint.right * _horizontalInput * _moveForce);
        _rigidbody.AddForce(_focalPoint.forward * _verticalInput * _moveForce);


        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void OnCollisionEnter(Collision other)
    {
        _isOnGround = true;
        //trying to simulate the level of audio due to the velocity of the player
        if (_rigidbody.velocity.magnitude > 0)
        {
            if (other.gameObject.CompareTag("Bed"))
                _audioSource.PlayOneShot(_bounceAudio, 1f);
            else
                _audioSource.PlayOneShot(_marbleAudio, _rigidbody.velocity.magnitude * .75f);
        }            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
            PowerUpPicked?.Invoke();
    }

    public void Jump()
    {
        if (_isOnGround)
        {
            _rigidbody.AddForce(_focalPoint.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }        
    }
}

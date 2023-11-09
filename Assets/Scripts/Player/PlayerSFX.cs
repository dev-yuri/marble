using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _bounceAudio;
    [SerializeField] private AudioClip _marbleAudio;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (_rigidbody.velocity.magnitude > 0)
        {
            if (other.gameObject.CompareTag("Bed"))
                _audioSource.PlayOneShot(_bounceAudio, 1f);
            else
                _audioSource.PlayOneShot(_marbleAudio, _rigidbody.velocity.magnitude * .75f);
        }
    }


}

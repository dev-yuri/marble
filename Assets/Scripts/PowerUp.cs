using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    [SerializeField] private GameObject _particle;
    [SerializeField] private AudioClip _audioEffect;
    private AudioSource _audio;

    
    private void Awake()
    {
        _audio = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject particleObj = Instantiate(_particle, transform.position, _particle.transform.rotation);
            
            _audio.PlayOneShot(_audioEffect, 1f);

            Destroy(gameObject);
            Destroy(particleObj, 1);            
        }            
    }
}

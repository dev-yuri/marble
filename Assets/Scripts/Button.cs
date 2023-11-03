using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    
    public delegate void ButtonAction();
    public event ButtonAction OnButtonPressed;

    private Animator _animator;   
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void ButtonPress()
    {
        OnButtonPressed?.Invoke();
        ButtonEffects();
    }

    public void Interact()
    {
        ButtonPress();
    }

    private void ButtonEffects()
    {
        _animator.SetTrigger("Press");
        _audioSource.PlayOneShot(_audioClip);
    }




}

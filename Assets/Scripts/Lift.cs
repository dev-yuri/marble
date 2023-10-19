using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Windows.Speech;

public class Lift : MonoBehaviour, IInteractable
{
    private float _maxRange;
    private float _minRange;
    private float _speed;
    private float _interactRange;
    
    private bool _isMoving;
    private bool _displayMessage;

    private Collider[] _colliderArray;

    // Update is called once per frame
    private void Start()
    {
        _maxRange = 5f;
        _minRange = 0.05f;
        _speed = 1f;
        _interactRange = 1f;
    }

    
    private void Update() 
    {
        DisplayBubble(_displayMessage);

        if (_isMoving && transform.position.y < _maxRange)
            transform.Translate(Vector3.up * Time.deltaTime * _speed);
        
        if (_isMoving && transform.position.y >= 0)
            transform.Translate(Vector3.up * Time.deltaTime * _speed);

        if (transform.position.y > _maxRange)
        {
            transform.position = new Vector3 (transform.position.x, _maxRange, transform.position.z);
            _isMoving = false;
            _speed = -_speed;
        }

        if (transform.position.y < _minRange)
        {
            transform.position = new Vector3 (transform.position.x, _minRange, transform.position.z);
            _isMoving = false;
            _speed = -_speed;
        }   
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            _displayMessage = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _displayMessage = false;
    }

    public void DisplayBubble(bool displayMessage)
    {
        if (displayMessage)
        {
            _colliderArray = Physics.OverlapSphere(transform.position, _interactRange);

            foreach (Collider collider in _colliderArray)
            {
                if (collider.TryGetComponent(out Player player))
                    Debug.Log("Bubble chat pops up");
            }
        }
    }

    public void Interact()
    {
        _isMoving = true;
        _displayMessage = false;
    }
         
}

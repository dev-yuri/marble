using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Lift1 : MonoBehaviour, IInteractable
{
    private float _maxRange;
    private float _minRange;
    [SerializeField] private float _speed;
    
    private bool _isMoving;
    // Update is called once per frame
    private void Start() {
        _maxRange = 5f;
        _minRange = 0.05f;
    }

    
    private void Update() 
    {
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

    public void Interact()
    {
        _isMoving = !_isMoving;
    }
         
}

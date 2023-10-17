using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Lift1 : MonoBehaviour
{
    private float _maxRange;
    private float _minRange;
    [SerializeField] private float _speed;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5 || transform.position.y <= 0)
            _speed = -_speed;

        transform.Translate(Vector3.up * Time.deltaTime * _speed );        
    }
}

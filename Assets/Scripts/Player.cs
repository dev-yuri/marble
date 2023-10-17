using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _focalPoint;
    private float _verticalInput;
    private float _horizontalInput;

    [SerializeField] private float _moveForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Camera").GetComponent<Transform>();
        _moveForce = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(_focalPoint.right * _horizontalInput * _moveForce);
        _rigidbody.AddForce(_focalPoint.forward * _verticalInput * _moveForce);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button14))
            _rigidbody.AddForce(_focalPoint.up * 5, ForceMode.Impulse);
    }
}

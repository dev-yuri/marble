using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _focalPoint;
    float _moveForce = 2f;
    float _jumpForce = 5f;

    void Awake()
    {
        _rigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Camera").GetComponent<Transform>(); 
    }


    Vector3 HandleInputMovement()   
    {
        Vector3 xDirection = _focalPoint.right * Input.GetAxis("Horizontal");
        Vector3 zDirection = _focalPoint.forward * Input.GetAxis("Vertical");

        return xDirection + zDirection;
    }

    public void Move()
    {
        Vector3 moveDirection = HandleInputMovement();
        Vector3 currentVelocity = CurrentVelocity();
        _rigidbody.AddForce(moveDirection * _moveForce - currentVelocity, ForceMode.VelocityChange);
    }

    Vector3 CurrentVelocity()
    {
        Vector3 currentVelocity = _rigidbody.velocity;
        currentVelocity.y = 0f; // to not interfere with gravity

        return currentVelocity;
    }

    public void Jump()
    {
        _rigidbody.AddForce(_focalPoint.up * _jumpForce, ForceMode.Impulse);
    }
    
}

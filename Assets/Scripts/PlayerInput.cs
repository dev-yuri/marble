using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Transform _focalPoint;


    void Awake()
    {
        //this is a parent object carrying the Main Camera
        _focalPoint = GameObject.Find("Camera").GetComponent<Transform>(); 
    }


    public Vector3 HandleInputMovement()   
    {
        Vector3 xDirection = _focalPoint.right * Input.GetAxis("Horizontal");
        Vector3 zDirection = _focalPoint.forward * Input.GetAxis("Vertical");

        return xDirection + zDirection;
    }

    // TODO: HandleInteraction, HandleCameraRotation
}

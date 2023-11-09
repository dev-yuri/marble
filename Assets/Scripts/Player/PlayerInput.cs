using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform FocalPoint {get; private set;}


    void Awake()
    {
        //this is a parent object carrying the Main Camera
        FocalPoint = GameObject.Find("Camera").GetComponent<Transform>(); 
    }


    public Vector3 HandleInputMovement()   
    {
        Vector3 xDirection = FocalPoint.right * Input.GetAxis("Horizontal");
        Vector3 zDirection = FocalPoint.forward * Input.GetAxis("Vertical");

        return xDirection + zDirection;
    }

    public bool HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            return true;
        }
            
        return false;
    }

    // TODO: HandleInteraction
}

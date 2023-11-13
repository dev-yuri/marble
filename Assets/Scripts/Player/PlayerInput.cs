using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform FocalPoint { get; private set; }


    void Awake()
    {
        //this is a parent object carrying the Main Camera
        FocalPoint = GameObject.Find("Camera").GetComponent<Transform>();
    }


    public Vector3 HandleInputMovement()
    {
        Vector3 xDirection = FocalPoint.right * Input.GetAxis("Horizontal");
        Vector3 zDirection = FocalPoint.forward * Input.GetAxis("Vertical");

        Vector3 direction = xDirection + zDirection;

        return direction.normalized;
    }

    public bool HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        return false;
    }

}

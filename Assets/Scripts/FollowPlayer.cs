using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _sensitivity;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _sensitivity = 1f;
    }

    // Update is called once per frame
    void LateUpdate()
    {    
        //the camera will follow the player and rotates around the player. for the rotation to work it's needed a offset on the Camera object (Inspector). It would be better to add directly in the code however, which is not done currently.

        transform.position = _player.position;

        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal-Rotation") * _sensitivity);
    }
}

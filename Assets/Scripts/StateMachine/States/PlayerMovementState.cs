using System;
using UnityEngine;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine stateMachine;

    protected Vector3 movementInput;
    protected float _moveForce = 5f;
    protected float _jumpForce = 5f;
    protected float _speedModifier = 1f;

    public PlayerMovementState (PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;
    }

    public virtual void Enter()
    {
        Debug.Log("State:" + GetType().Name);
    }

    public virtual void Exit()
    {
        
    }

    public virtual void HandleInput()
    {
        //ReadMovementInput();
    } 

    public virtual void PhysicsUpdate()
    {
       Move();
    }

    public virtual void Update()
    {
        
    }

    protected Vector3 ReadMovementInput()
    {
        return stateMachine.Player.Input.HandleInputMovement();
    }

    private void Move()
    {
        Vector3 moveDirection = ReadMovementInput();

        if (moveDirection == Vector3.zero || _speedModifier == 0f)
            return;
        Vector3 currentVelocity = CurrentVelocity();

        stateMachine.Player.Rigidbody.AddForce(moveDirection * _moveForce * _speedModifier - currentVelocity, ForceMode.VelocityChange);
    }

    Vector3 CurrentVelocity()
    {
        Vector3 currentVelocity = stateMachine.Player.Rigidbody.velocity;
        currentVelocity.y = 0f; // to not interfere with gravity

        return currentVelocity;
    }
}
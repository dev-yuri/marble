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
    } 

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        if(stateMachine.Player.transform.position.y < -5)
        {
            stateMachine.Player.Rigidbody.velocity = new Vector3(0f, 0f, 0f);
            stateMachine.Player.transform.position = new Vector3(10f, 10f, 10f);
        }
            
    }

    protected Vector3 MovementInput()
    {
        return stateMachine.Player.Input.HandleInputMovement();
    }

    protected bool JumpInput()
    {
        return stateMachine.Player.Input.HandleJump();
    }

    protected Vector3 CurrentVelocity()
    {
        Vector3 currentVelocity = stateMachine.Player.Rigidbody.velocity;
        currentVelocity.y = 0f; // to not interfere with gravity

        return currentVelocity;
    }

    protected void ResetVelocity()
    {
        stateMachine.Player.Rigidbody.velocity = new Vector3(0f, stateMachine.Player.Rigidbody.velocity.y, 0f);
    }
}
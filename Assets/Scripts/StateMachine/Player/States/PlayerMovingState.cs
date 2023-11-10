using UnityEngine;

public class PlayerMovingState : PlayerMovementState
{
    public PlayerMovingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();

        if (JumpInput())
            OnJump();

        if (MovementInput() == Vector3.zero)
            OnStop();    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = MovementInput();

        Vector3 currentVelocity = CurrentVelocity();

        stateMachine.Player.Rigidbody.AddForce(moveDirection * _moveForce * _speedModifier - currentVelocity, ForceMode.VelocityChange);
    }

    private void OnStop()
    {
        stateMachine.ChangeState(stateMachine.IdlingState);
    }

    private void OnJump()
    {
        stateMachine.ChangeState(stateMachine.JumpingState);
    }
}

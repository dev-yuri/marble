using UnityEngine;

public class PlayerJumpingState : PlayerMovementState
{
    public PlayerJumpingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.Player.Rigidbody.AddForce(_jumpForce * stateMachine.Player.Input.FocalPoint.up, ForceMode.Impulse);
        stateMachine.Player.Grounded = false;
    }

    public override void PhysicsUpdate()
    {
        base.Update();
        if (stateMachine.Player.Grounded)
            stateMachine.ChangeState(stateMachine.IdlingState);        
    }
}

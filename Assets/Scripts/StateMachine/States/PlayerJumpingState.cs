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
    }
}

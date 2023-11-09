using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdlingState : PlayerMovementState
{
    public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Rigidbody.velocity != Vector3.zero)      
            ResetVelocity();

        if (JumpInput() && stateMachine.Player.Grounded)
            OnJump();

        if (MovementInput() == Vector3.zero)
            return;
        OnMove();
    }

    private void OnMove()
    {
        stateMachine.ChangeState(stateMachine.MovingState);
    }

    private void OnJump()
    {
        stateMachine.ChangeState(stateMachine.JumpingState);
    }
}

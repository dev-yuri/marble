using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdlingState : PlayerMovementState
{
    public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _speedModifier = 0f;
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Input.HandleInputMovement() == Vector3.zero)
            return;
        OnMove();
    }

    private void OnMove()
    {
        stateMachine.ChangeState(stateMachine.MovingState);
    }
}

using UnityEngine;

public class PlayerMovingState : PlayerMovementState
{
    public PlayerMovingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Input.HandleInputMovement() == Vector3.zero)
            OnStop();
    }

    private void OnStop()
    {
        stateMachine.ChangeState(stateMachine.IdlingState);
    }
}

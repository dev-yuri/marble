using UnityEngine;

public class PlayerIdlingState : PlayerMovementState
{
    public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region "IState methods"
    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Rigidbody.velocity != Vector3.zero)      
            ResetVelocity();

        if (JumpInput() && stateMachine.Player.Grounded)
            OnJump();

        else if (MovementInput() == Vector3.zero)
            return;
        
        else if (InteractableObjectName() == "Ladder")
            OnLadder();
        else 
            OnMove();
    }
    #endregion

    #region "Other methods"
    private void OnMove()
    {
        stateMachine.ChangeState(stateMachine.MovingState);
    }

    private void OnJump()
    {
        stateMachine.ChangeState(stateMachine.JumpingState);
    }

    private void OnLadder()
    {
        stateMachine.ChangeState(stateMachine.PlayerStairState);
    }
    #endregion
}
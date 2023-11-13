using UnityEngine;

public class PlayerMovingState : PlayerMovementState
{
    public PlayerMovingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region "IState methods"
    public override void Update()
    {
        base.Update();

        if (JumpInput() && stateMachine.Player.Grounded)
            OnJump();

        if (MovementInput() == Vector3.zero)
            OnStop();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move();
    }
    #endregion

    #region "Other methods"
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
    #endregion


}

using UnityEngine;

public class PlayerStairState : PlayerMovementState
{
    public PlayerStairState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region "IState methods"
    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.Rigidbody.useGravity = false;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        MoveLadder();
    }
    
    public override void Exit()
    {
        stateMachine.Player.Rigidbody.useGravity = true;
        stateMachine.Player.Interaction.ObjectName = "any";

        base.Exit();
    }
    
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End of ladder"))
            stateMachine.ChangeState(stateMachine.IdlingState);
    }
    
    #endregion

    #region "Other methods"
    void MoveLadder()
    {
        Vector3 direction = stateMachine.Player.Input.HandleInputLadder();
        Vector3 currentVelocity = YCurrentVelocity();

        stateMachine.Player.Rigidbody.AddForce(direction * _moveForce * _speedModifier - currentVelocity, ForceMode.VelocityChange);
    }

    #endregion

}

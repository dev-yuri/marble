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

    public override void Update()
    {
        base.Update();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        MoveLadder();
    }
    
    public override void Exit()
    {
        stateMachine.Player.Rigidbody.useGravity = true;
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
        Vector3 direction = MovementInput();
        Vector3 currentVelocity = YCurrentVelocity();

        direction.y = direction.z;
        direction.x = 0;
        direction.z = 0;

        stateMachine.Player.Rigidbody.AddForce(direction * _moveForce * _speedModifier - currentVelocity, ForceMode.VelocityChange);
    }

    #endregion

}

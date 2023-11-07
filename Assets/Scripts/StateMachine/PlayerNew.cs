using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    PlayerMovementStateMachine movementStateMachine;

    private void Awake()
    {
        movementStateMachine = new PlayerMovementStateMachine();
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void Update()
    {
        movementStateMachine.HandleInput();
        movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();
    }
}
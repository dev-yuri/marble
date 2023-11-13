using UnityEngine;

public abstract class StateMachine
{
    protected IState CurrentState {get; private set;} 

    public void ChangeState(IState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    /*public void HandleInput()
    {
        CurrentState?.HandleInput();
    }*/

    public void Update()
    {
        CurrentState?.Update();
    }

    public void PhysicsUpdate()
    {
        CurrentState?.PhysicsUpdate();
    }

    public void OnTriggerEnter(Collider other)
    {
        CurrentState?.OnTriggerEnter(other);
    }
}

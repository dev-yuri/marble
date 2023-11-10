using UnityEngine;

public class PlayingState : IState
{
    GameStateMachine GameStateMachine;
    public PlayingState(GameStateMachine gameStateMachine)
    {
        GameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
       Debug.Log("Game state: " + GetType().Name);
    }

    public void Exit()
    {
        
    }

    public void HandleInput()
    {
        
    }

    public void PhysicsUpdate()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            GameStateMachine.ChangeState(new PausedState(GameStateMachine));
            // if the "PausedState" is chached in the GameStateMachine
            // GameStateMachine.ChangeState(GameStateMachine.PausedState);

    }
}
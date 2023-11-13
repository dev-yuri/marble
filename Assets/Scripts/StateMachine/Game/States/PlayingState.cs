using UnityEngine;

public class PlayingState : IState
{
    GameStateMachine GameStateMachine;
    public PlayingState(GameStateMachine gameStateMachine)
    {
        GameStateMachine = gameStateMachine;
    }

    #region "IState methods"
    public void Enter()
    {
        Debug.Log("Game state: " + GetType().Name);
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            GameStateMachine.ChangeState(new PausedState(GameStateMachine));
        // if the "PausedState" is chached in the GameStateMachine
        // GameStateMachine.ChangeState(GameStateMachine.PausedState);
    }

    public void OnTriggerEnter(Collider other)
    {        
    }

    public void PhysicsUpdate()
    {        
    }

    #endregion
}
using UnityEngine;

public class PausedState : IState
{
    GameStateMachine GameStateMachine;
    public PausedState(GameStateMachine gameStateMachine)
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
            GameStateMachine.ChangeState(new PlayingState(GameStateMachine));
            // if the "PlayingState" is chached in the GameStateMachine
            // GameStateMachine.ChangeState(GameStateMachine.PlayingState);     
    }

    
    public void OnTriggerEnter(Collider other)
    {        
    }

    public void PhysicsUpdate()
    {        
    }

    #endregion
}
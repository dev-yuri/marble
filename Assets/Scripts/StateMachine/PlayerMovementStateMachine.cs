public class PlayerMovementStateMachine : StateMachine
{
    public PlayerIdlingState IdlingState {get; }
    public PlayerMovingState MovingState {get; }
    public PlayerJumpingState JumpingState {get; }

    public PlayerMovementStateMachine()
    {
        IdlingState = new PlayerIdlingState();
        MovingState = new PlayerMovingState();
        JumpingState = new PlayerJumpingState();
    }
}
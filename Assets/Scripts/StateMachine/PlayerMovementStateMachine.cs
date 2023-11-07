public class PlayerMovementStateMachine : StateMachine
{
    public PlayerNew Player {get; }
    public PlayerIdlingState IdlingState {get; }
    public PlayerMovingState MovingState {get; }
    public PlayerJumpingState JumpingState {get; }

    public PlayerMovementStateMachine(PlayerNew player)
    {
        Player = player;
        IdlingState = new PlayerIdlingState(this);
        MovingState = new PlayerMovingState(this);
        JumpingState = new PlayerJumpingState(this);
    }
}
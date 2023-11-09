public class PlayerMovementStateMachine : StateMachine
{
    public PlayerController Player {get; }
    public PlayerIdlingState IdlingState {get; }
    public PlayerMovingState MovingState {get; }
    public PlayerJumpingState JumpingState {get; }

    public PlayerMovementStateMachine(PlayerController player)
    {
        Player = player;
        IdlingState = new PlayerIdlingState(this);
        MovingState = new PlayerMovingState(this);
        JumpingState = new PlayerJumpingState(this);
    }
}
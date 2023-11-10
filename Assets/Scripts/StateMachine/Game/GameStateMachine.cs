public class GameStateMachine : StateMachine
{
    public GameManager GameManager {get; }
    // caching the states
    //public PlayingState PlayingState {get; }
    //public PausedState PausedState {get; }

    public GameStateMachine (GameManager gameManager)
    {
        GameManager = gameManager;

        // caching the states
        //PlayingState = new PlayingState(this);
        //PausedState = new PausedState(this);
    }
}

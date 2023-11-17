using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovementStateMachine movementStateMachine;

    public PlayerInput Input { get; private set; }
    public PlayerInteraction Interaction {get; private set;}
    public Rigidbody Rigidbody { get; private set; }
    public bool Grounded { get; set; }


    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Interaction = GetComponent<PlayerInteraction>();
        Rigidbody = GetComponent<Rigidbody>();

        movementStateMachine = new PlayerMovementStateMachine(this);

        Grounded = false;
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void Update()
    {
        movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();
    }

    private void OnTriggerEnter(Collider other) 
    {
        movementStateMachine.OnTriggerEnter(other);
    }

    private void OnCollisionEnter(Collision other)
    {
        Grounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        Grounded = false;
    }
}
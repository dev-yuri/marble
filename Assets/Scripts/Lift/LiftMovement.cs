using UnityEngine;

public class LiftMovement : MonoBehaviour, IInteractable
{

    [SerializeField] private float _maxRange;
    private float _minRange;
    private float _speed = 1f;
    public bool IsMoving {get; private set;}
    public enum Direction { Up, Down }
    public Direction direction {get; private set;}
    [SerializeField] private Button _liftButton;


    private void Start()
    {
        _minRange = transform.position.y;
    }
    private void OnEnable()
    {
        _liftButton.OnButtonPressed += Interact;
    }

    private void OnDestroy()
    {
        _liftButton.OnButtonPressed -= Interact;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            if (direction == Direction.Up)
                Move(Direction.Up);
            else if (direction == Direction.Down)
                Move(Direction.Down);
        }

        if (transform.position.y > _maxRange)
        {
            transform.position = new Vector3(transform.position.x, _maxRange, transform.position.z);
            IsMoving = false;
            direction = Direction.Down;
        }

        if (transform.position.y <= _minRange)
        {
            transform.position = new Vector3(transform.position.x, _minRange, transform.position.z);
            IsMoving = false;
            direction = Direction.Up;
        }
    }

    void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
                break;
            case Direction.Down:
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
                break;
            default:
                break;
        }
    }

    public void Interact()
    {
        IsMoving = true;
    }
}

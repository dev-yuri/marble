using TMPro;
using UnityEngine;

public class Lift : MonoBehaviour, IInteractable
{
    private float _maxRange;
    private float _minRange;
    private float _speed;
    private bool _isMoving;
    public enum Direction {Up, Down}
    private Direction _direction;
    private TextMeshPro _textMessage;
    private SpriteRenderer _background;
    private Transform _message;
    private Transform _lookAt;

    private LiftButton _liftButton;

    // Update is called once per frame
    private void Start()
    {
        _maxRange = 5f;
        _minRange = 0.05f;
        _speed = 1f;
        
        _textMessage = transform.Find("Message/Text").GetComponent<TextMeshPro>();
        _background = transform.Find("Message/Background").GetComponent<SpriteRenderer>();
        _message = transform.Find("Message").GetComponent<Transform>();

        _message.transform.gameObject.SetActive(false);
        
        _lookAt = GameObject.Find("Camera").GetComponent<Transform>();

        _liftButton = GameObject.Find("LiftButton").GetComponent<LiftButton>();
        _liftButton.OnButtonPressed += Interact;
    }

    private void OnDestroy()
    {
        _liftButton.OnButtonPressed -= Interact;
    }


    private void Update() 
    {
        if (_isMoving)
        {
            if (_direction == Direction.Up)
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
            else if (_direction == Direction.Down)
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
        }        
        
        if (transform.position.y > _maxRange)
        {
            transform.position = new Vector3 (transform.position.x, _maxRange, transform.position.z);
            _isMoving = false;
            _direction = Direction.Down;
        }

        if (transform.position.y <= _minRange)
        {
            transform.position = new Vector3 (transform.position.x, _minRange, transform.position.z);
            _isMoving = false;
            _direction = Direction.Up;
        }

        _message.transform.rotation = _lookAt.transform.rotation;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && _isMoving == false)
        {
            DisplayMessage(_direction);
            _message.gameObject.SetActive(true);
        }

    }
    private void OnCollisionExit(Collision other)
    {
        _message.gameObject.SetActive(false);
    }

    private void DisplayMessage(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                _textMessage.text = "Up";
                break;
            case Direction.Down:
                _textMessage.text = "Down";
                break;
            default:
                break;
        }

        _background.size = new Vector2(_textMessage.preferredWidth + .2f, _textMessage.preferredHeight + .2f);
    }

    public void Interact()
    {
        _isMoving = true;
        _message.gameObject.SetActive(false);

        // if (transform.position.y == _maxRange)
        //      Move(Direction.Down);
        // else if (transform.position.y == _minRange)
        //      Move(Direction.Up);
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                //_animator.SetBool("Up", true);
                break;
            case Direction.Down:
                //_animator.SetBool("Down", true);
                break;
            default:
                break;
        }
    }


}

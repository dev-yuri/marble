using UnityEngine;

public class Lift2 : MonoBehaviour, IInteractable
{
    private float _maxRange;
    private float _minRange;
    private enum Direction {Up, Down}

    private Animator _animator;
    private Transform _cabin;  

    // Update is called once per frame
    private void Start()
    {
        _maxRange = 5.05f;
        _minRange = 0.05f;
        _cabin = transform.Find("Cabin").GetComponent<Transform>();
        _animator = transform.Find("Cabin").GetComponent<Animator>();
    }

    public void Interact()
    {           
        if (_cabin.position.y == _maxRange)
        {
            _animator.SetBool("Up", false);
            Move(Direction.Down);
        }
            
        else if (_cabin.position.y == _minRange)
        {
            _animator.SetBool("Down", false);
            Move(Direction.Up);
        }            
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                _animator.SetBool("Up", true);
                break;
            case Direction.Down:
                _animator.SetBool("Down", true);
                break;
            default:
                break;
        }
    }
}

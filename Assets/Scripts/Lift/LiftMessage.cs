using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class LiftMessage : MonoBehaviour
{
    private TextMeshPro _textMessage;
    private SpriteRenderer _background;
    private Transform _message;
    private Transform _lookAt;
    private LiftMovement _lift;
    
    // Start is called before the first frame update
    void Start()
    {
        _textMessage = transform.Find("Message/Text").GetComponent<TextMeshPro>();
        _background = transform.Find("Message/Background").GetComponent<SpriteRenderer>();
        _message = transform.Find("Message").GetComponent<Transform>();
        _lift = transform.GetComponent<LiftMovement>();

        _message.transform.gameObject.SetActive(false);

        _lookAt = GameObject.Find("Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _message.transform.rotation = _lookAt.transform.rotation;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && _lift.IsMoving == false)
        {
            DisplayMessage(_lift.direction);
            _message.gameObject.SetActive(true);
        }

        if (_lift.IsMoving)
            DisableMessage();

    }
    private void OnCollisionExit(Collision other)
    {
        DisableMessage();
    }

    private void DisplayMessage(LiftMovement.Direction direction)
    {
        switch (direction)
        {
            case LiftMovement.Direction.Up:
                _textMessage.text = "Press G to go up";
                break;
            case LiftMovement.Direction.Down:
                _textMessage.text = "Press G to go down";
                break;
            default:
                break;
        }
        _background.size = new Vector2(_textMessage.preferredWidth + .2f, _textMessage.preferredHeight + .2f);
    }

    void DisableMessage()
    {
        _message.gameObject.SetActive(false);
    }
}

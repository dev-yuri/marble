using UnityEngine;

public class LiftButton : MonoBehaviour, IInteractable
{
    
    public delegate void LiftAction();
    public event LiftAction OnButtonPressed;

    // Start is called before the first frame update
    public void Button()
    {
        OnButtonPressed?.Invoke();
    }

    public void Interact()
    {
        Button();
    }
}

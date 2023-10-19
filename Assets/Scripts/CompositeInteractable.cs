using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> _interactableObjects;
    // Update is called once per frame
    public void Interact()
    {
        foreach (GameObject _interactableObject in _interactableObjects)
        {
            if (_interactableObject.TryGetComponent<IInteractable>(out IInteractable interactable))
                interactable.Interact();
        }
            
    }

    public void DisplayBubble(bool displayMessage)
    {

    }
}

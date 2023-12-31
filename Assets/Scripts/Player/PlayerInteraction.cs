using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange;
    private Collider[] colliderArray;

    public string ObjectName {get; set;}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerInteract();
        }           
    }
    private void PlayerInteract()
    {
        colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactableObject))
            {
                interactableObject.Interact();
                ObjectName = collider.gameObject.name;
            }
        }
    }
}

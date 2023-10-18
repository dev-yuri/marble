using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange;
    private Collider[] colliderArray;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
             colliderArray = Physics.OverlapSphere(transform.position, interactRange);
             foreach (Collider collider in colliderArray)
             {
                if (collider.TryGetComponent(out IInteractable interactbleObject))
                    interactbleObject.Interact();
             }
                
        }

       
    }
}

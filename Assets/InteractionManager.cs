using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public IInteractable currentInteractable;

    public string interactableLayer;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.NameToLayer(interactableLayer);

        if (Physics.Raycast(ray, out hit, 50, ~mask.value))
        {
            if (hit.transform.gameObject.GetComponent<IInteractable>() != null)
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance);
                SetInteractable(hit.transform.gameObject.GetComponent<IInteractable>());
            }

            // Do something with the object that was hit by the raycast.
        }
        else
        {
            SetInteractable(null);
        }

        if (Input.GetMouseButtonDown(0) & currentInteractable != null)
        {
            currentInteractable.interact();
        }
    }

    void SetInteractable(IInteractable interactable)
    {
        if (interactable == currentInteractable) return;

        if (currentInteractable != null)
        {
            currentInteractable.loseFocus();
        }

        currentInteractable = interactable;

        if (interactable != null)
        {
            interactable.Focus();
        }
    }
}

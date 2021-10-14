using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPoint : MonoBehaviour
{
    public UnityEvent playerInteract;

    public Color gizmoDrawColour = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoDrawColour;

        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Ping");
            playerInteract.Invoke();
        }
    }
}

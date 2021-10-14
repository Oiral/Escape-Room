using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseInteract : MonoBehaviour
{
    public UnityEvent<bool> onClick;

    private void OnMouseDown()
    {
        onClick.Invoke(true);
    }

    public Moveable move;

    private void OnMouseEnter()
    {
        move.Toggle(true);
    }

    private void OnMouseExit()
    {
        move.Toggle(false);
    }
}

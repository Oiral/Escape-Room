using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionEvents : InteractionCamera
{
    public UnityEvent onInteraction;
    public UnityEvent onFocus;
    public UnityEvent onLoseFocus;

    public override void interact()
    {
        onInteraction.Invoke();
        SetCamera();
    }

    public override void loseFocus()
    {
        onLoseFocus.Invoke();
    }

    public override void Focus()
    {
        onFocus.Invoke();
    }
}

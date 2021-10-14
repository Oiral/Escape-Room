using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCamera : MonoBehaviour, IInteractable
{
    public Transform cameraViewPoint;
    public virtual void Focus()
    {

    }

    public virtual void interact()
    {
        SetCamera();
    }

    public virtual void loseFocus()
    {

    }

    public void SetCamera()
    {
        CameraManager.instance.SetTarget(cameraViewPoint);
    }
}

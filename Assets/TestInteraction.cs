using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TestInteraction : MonoBehaviour, IInteractable
{
    public MeshRenderer meshRender;

    public Transform cameraViewPoint;

    public Material onFocusMat;
    public Material loseFocusMat;

    public void interact()
    {
        //transform.position += Vector3.up;
        CameraManager.instance.SetTarget(cameraViewPoint);
    }

    public void loseFocus()
    {
        meshRender.material = loseFocusMat;
    }

    public void Focus()
    {
        meshRender.material = onFocusMat;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(this);
        }
    }

    public Transform targetTransform;

    public Transform mainPlayerTransform;

    public Transform cameraTransform;

    public void SetTarget(Transform target)
    {
        targetTransform = target;
        cameraTransform.Lerp(target, 1f);
    }

    private void Update()
    {
        if (targetTransform == null)
        {
            cameraTransform.MirrorTransform(mainPlayerTransform);
        }
    }
}

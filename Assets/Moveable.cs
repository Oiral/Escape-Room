using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[SerializeField]
public class Moveable : MonoBehaviour
{
    public bool open;


    public Transform openTransform;

    public Transform closedTransform;

    public Transform visualTransform;

    //public Vector3 openPos;

    //Vector3 closedPos;

    public float openSpeed = 5f;

    private void Start()
    {
        //closedPos = transform.localPosition;
    }

    private void Update()
    {
        //Vector3 targetPos = open ? openPos : closedPos;

        Transform targetTransform = open ? openTransform : closedTransform;

        //transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, openSpeed * Time.deltaTime);

        LerpTransform(visualTransform, targetTransform, openSpeed * Time.deltaTime);
    }

    

    public void Toggle()
    {
        Toggle(!open);
    }

    public void Toggle(bool state)
    {
        open = state;
    }

    public void LerpTransform(Transform currentTransform, Transform previousTransform, float amount)
    {
        currentTransform.position = Vector3.Lerp(currentTransform.position, previousTransform.position, amount);
        currentTransform.rotation = Quaternion.Lerp(currentTransform.rotation, previousTransform.rotation, amount);
        currentTransform.localScale = Vector3.Lerp(currentTransform.localScale, previousTransform.localScale, amount);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(openTransform.position, Vector3.one * 0.2f);
        Gizmos.DrawWireCube(closedTransform.position, Vector3.one * 0.2f);
        Gizmos.DrawLine(openTransform.position, closedTransform.position);
    }

    [ContextMenu("Set/Closed Position")]
    public void SetClosedPosition()
    {
        TransferTransform(closedTransform, visualTransform);
    }

    [ContextMenu("Set/Open Position")]
    public void SetOpenPosition()
    {
        TransferTransform(openTransform, visualTransform);
    }

    [ContextMenu("Move/Open Position")]
    public void SetOpen()
    {
        TransferTransform(visualTransform, openTransform);
    }

    [ContextMenu("Move/Closed Position")]
    public void SetClosed()
    {
        TransferTransform(visualTransform, closedTransform);
    }

    public void TransferTransform(Transform currentTransform, Transform targetTransform)
    {
        currentTransform.position = targetTransform.position;
        currentTransform.rotation = targetTransform.rotation;
        currentTransform.localScale = targetTransform.localScale;

    }

#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    /// <summary>
    /// Lerp to transform over set period of time
    /// </summary>
    public static void Lerp(this Transform myTransform, Transform targetTransform, float waitTime)
    {
        PerformCoroutine(lerpToIEnum(myTransform, targetTransform, waitTime));
    }

    static IEnumerator lerpToIEnum(Transform myTransform, Transform target, float waitTime)
    {
        if (waitTime < 0) throw new System.ArgumentException("Wait time needs to be greater than 0", nameof(waitTime));

        float elapsedTime = 0f;

        Vector3 startingPosition = myTransform.position;
        Vector3 startingScale = myTransform.localScale;
        Quaternion startingRotation = myTransform.rotation;

        while (elapsedTime < waitTime)
        {
            myTransform.position = Vector3.Lerp(startingPosition, target.position, (elapsedTime / waitTime));
            myTransform.localScale = Vector3.Lerp(startingScale, target.localScale, (elapsedTime / waitTime));
            myTransform.rotation = Quaternion.Lerp(startingRotation, target.rotation, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        myTransform.MirrorTransform(target);
        yield return null;
    }

    #region coroutine Help

    //Create a class that actually inheritance from MonoBehaviour
    public class TransformExtensionsMB : MonoBehaviour { }


    //Variable reference for the class
    private static TransformExtensionsMB tansformExtensionsMB;


    //Now Initialize the variable (instance)
    private static void Init()
    {
        //If the instance not exit the first time we call the static class
        if (tansformExtensionsMB == null)
        {
            //Create an empty object called MyStatic
            GameObject gameObject = new GameObject("TransformExtensions");


            //Add this script to the object
            tansformExtensionsMB = gameObject.AddComponent<TransformExtensionsMB>();
        }
    }

    //Now, a simple function
    public static void PerformCoroutine(IEnumerator routine)
    {
        //Call the Initialization
        Init();


        //Call the Coroutine
        tansformExtensionsMB.StartCoroutine(routine);
    }
    #endregion

    /// <summary>
    /// Set transforms position, rotation and scale
    /// </summary>
    public static void MirrorTransform(this Transform myTransform, Transform targetTransform)
    {
        myTransform.position = targetTransform.position;
        myTransform.rotation = targetTransform.rotation;
        myTransform.localScale = targetTransform.localScale;
    }
}

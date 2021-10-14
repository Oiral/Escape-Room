using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDisplayManager : MonoBehaviour
{
    public static PuzzleDisplayManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Duplicate puzzle display manager",gameObject);
            Destroy(this);
        }
    }

    public GameObject currentPuzzle;
}

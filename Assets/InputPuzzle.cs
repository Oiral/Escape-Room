using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPuzzle : MonoBehaviour, IPuzzle
{
    public Moveable puzzlePoint;
    public List<GameObject> toEnable = new List<GameObject>();

    public bool completed { get => _complete; set => _complete = value; }

    bool _complete = false;

    public void CompletePuzzle()
    {
        completed = true;

        gameObject.SetActive(false);
        puzzlePoint.Toggle(true);

        for (int i = 0; i < toEnable.Count; i++)
        {
            toEnable[i].SetActive(true);
        }
    }

    public InputField inputField;

    public string puzzleCompletionString;

    public void CheckPuzzle()
    {
        if (inputField.text == puzzleCompletionString)
        {
            CompletePuzzle();
        }
    }
}

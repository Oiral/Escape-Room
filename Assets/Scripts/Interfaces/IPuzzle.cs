using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle
{
    public bool completed { get; set; }

    public void CompletePuzzle();

    public void CheckPuzzle();
}

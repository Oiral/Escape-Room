using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleInteractionPoint : InteractionPoint
{
    public UnityEvent<bool> onCompletePuzzle;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Focus();

    public void loseFocus();

    public void interact();

}

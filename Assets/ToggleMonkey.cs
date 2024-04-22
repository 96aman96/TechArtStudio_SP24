using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMonkey : MonoBehaviour
{
    public MonkeyMover mm;

    public void MoveMonkey()
    {
        mm.ReadyToMove = true;
    }
}

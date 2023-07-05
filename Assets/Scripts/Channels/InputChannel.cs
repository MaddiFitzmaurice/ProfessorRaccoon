using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class InputChannel
{
    public static Action<Vector2> MoveEvent;

    public static void RaiseMoveEvent(Vector2 value)
    {
        MoveEvent?.Invoke(value);
    }
}

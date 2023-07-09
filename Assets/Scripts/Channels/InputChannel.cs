using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public static class InputChannel
{
    public static Action<InputAction.CallbackContext> MoveEvent;

    public static void RaiseMoveEvent(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions 
{
    private GameInput _inputActions;

    private void Awake()
    {
        _inputActions = new GameInput();
        _inputActions.Gameplay.Enable();
        _inputActions.Gameplay.SetCallbacks(this);
    }

    private void OnDestroy()
    {
        _inputActions.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InputChannel.RaiseMoveEvent(context.ReadValue<Vector2>());
        }
        else if (context.canceled)
        {
            InputChannel.RaiseMoveEvent(context.ReadValue<Vector2>());
        }
    }
}

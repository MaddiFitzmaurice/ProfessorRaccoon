using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions 
{
    private GameInput _inputActions;

    private void Awake()
    {
        InputInitialisation();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void InputInitialisation()
    {
        _inputActions = new GameInput();
        GameplayControlsEnabled();
        _inputActions.Gameplay.SetCallbacks(this);
    }

    public void GameplayControlsEnabled()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _inputActions.Gameplay.Enable();
        _inputActions.UI.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            InputChannel.RaiseJumpEvent(context);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            InputChannel.RaiseMoveEvent(context);
        }
    }

    public void OnLook(InputAction.CallbackContext context) {}

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InputChannel.RaiseSprintEvent(context);
        }
    }
}

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
        _inputActions.Gameplay.Enable();
        _inputActions.UI.Disable();
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
        if (!context.performed)
        {
            InputChannel.RaiseMoveEvent(context);
        }
    }
}

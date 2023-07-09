using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerBaseState
{
    protected static Vector2 MoveInput = Vector2.zero;
    protected static bool JumpInput = false;

    public PlayerMoveState(Player player) : base(player) {}

    public override void Enter()
    {
        InputChannel.MoveEvent += OnMove;
        InputChannel.JumpEvent += OnJump;
    }

    public override void Exit()
    {
        InputChannel.MoveEvent -= OnMove;
        InputChannel.JumpEvent -= OnJump;
    }

    // Receive input from InputManager
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }
}

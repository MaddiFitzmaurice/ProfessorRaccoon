using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerBaseState
{
    protected static Vector2 MoveInput = Vector2.zero;

    public PlayerMoveState(Player player) : base(player) {}

    public override void Enter()
    {
        //Debug.Log("MoveState Entered");
        InputChannel.MoveEvent += OnMove;
    }

    public override void Exit()
    {
        InputChannel.MoveEvent -= OnMove;
    }

    // Receive input from InputManager
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(Player player) : base(player) {}

    public override void Enter()
    {
        Debug.Log("Entered IdleState");

        InputChannel.MoveEvent += OnMove;
    }

    public override void Exit()
    {
        InputChannel.MoveEvent -= OnMove;
    }

    public void OnMove(Vector2 value)
    {
        if (value.magnitude != 0)
        {
            Player.StateMachine.ChangeState(Player.States.WalkState);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(Player player) : base(player) {}

    public override void Enter()
    {
        Debug.Log("Entered WalkState");

        InputChannel.MoveEvent += OnIdle;
    }

    public override void Exit()
    {
        InputChannel.MoveEvent -= OnIdle;
    }

    public void OnIdle(Vector2 value)
    {
        if (value.magnitude == 0)
        {
            Player.StateMachine.ChangeState(Player.States.IdleState);
        }
    }
}

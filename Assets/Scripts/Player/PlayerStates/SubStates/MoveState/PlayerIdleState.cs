using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerMoveState
{
    public PlayerIdleState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered IdleState");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        if (MoveInput != Vector2.zero)
        {
            Player.StateMachine.ChangeState(Player.States.WalkState);
        }
    }
}

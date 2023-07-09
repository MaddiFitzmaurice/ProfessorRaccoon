using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerMoveState
{
    public PlayerWalkState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered WalkState");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        if (MoveInput == Vector2.zero)
        {
            Player.StateMachine.ChangeState(Player.States.IdleState);
        }
        else if (JumpInput)
        {
            Player.StateMachine.ChangeState(Player.States.JumpState);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Player.DataChange(Player.WalkData);
        Debug.Log("Entered IdleState");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        if (MoveInput != Vector3.zero)
        {
            Player.StateMachine.ChangeState(Player.States.WalkState);
        }
        else if (JumpInput)
        {
            Player.StateMachine.ChangeState(Player.States.JumpState);
        }
    }
}

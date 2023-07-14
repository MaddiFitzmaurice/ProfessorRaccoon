using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
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

        if (JumpInput && IsGrounded())
        {
            Player.StateMachine.ChangeState(Player.States.JumpState);
        }
        else if (MoveInput == Vector3.zero)
        {
            Player.StateMachine.ChangeState(Player.States.IdleState);
        }
        else if (Player.Rb.velocity.y < -0.1f && !IsGrounded())
        {
            Player.StateMachine.ChangeState(Player.States.FallState);
        }
    }

    public override void PhysicsUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }
}

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
        Player.DataChange(Player.WalkData);
        Player.Animator.SetBool("IsWalking", true);
    }

    public override void Exit()
    {
        base.Exit();
        Player.Animator.SetBool("IsWalking", false);
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
        else if (SprintInput)
        {
            Player.StateMachine.ChangeState(Player.States.SprintState);
        }
    }

    public override void PhysicsUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }
}

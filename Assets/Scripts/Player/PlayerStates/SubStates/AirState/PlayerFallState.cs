using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered FallState");
        Player.Animator.SetBool("IsFalling", true);
    }

    public override void Exit()
    {
        base.Exit();
        Player.Animator.SetBool("IsFalling", false);
    }

    public override void LogicUpdate()
    {
        if (IsGrounded())
        {
            Player.StateMachine.ChangeState(Player.States.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        PlayerAirMovement();
        PlayerRotation();
    }

}

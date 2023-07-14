using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float _jumpTime;
    private const float JumpBuffer = 0.15f;

    public PlayerJumpState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered JumpState");
        _jumpTime = 0;
        Jump();
    }

    public override void LogicUpdate()
    {
        if (Player.Rb.velocity.y < 0.1f && _jumpTime > JumpBuffer)
        {
            Player.StateMachine.ChangeState(Player.States.FallState);
        }

        _jumpTime += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        PlayerAirMovement();
        PlayerRotation();
    }

    public override void Exit()
    {
        base.Exit();
    }
}


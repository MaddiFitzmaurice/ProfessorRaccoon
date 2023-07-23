using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseJumpState : PlayerBaseState
{
    protected float JumpTime;
    protected const float JumpBuffer = 0.15f;

    public PlayerBaseJumpState(Player player) : base(player) { }

    public override void Enter()
    {
        base.Enter();
        JumpTime = 0;
        Jump();
        Player.DataChange(Player.InAirData);
    }

    public override void LogicUpdate()
    {
        if (Player.Rb.velocity.y < 0.1f && JumpTime > JumpBuffer)
        {
            Player.StateMachine.ChangeState(Player.States.FallState);
        }

        JumpTime += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }

    protected abstract void Jump();
}

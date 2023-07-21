using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    private float _sprintTimer;

    public PlayerSprintState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered SprintState");
        Player.DataChange(Player.SprintData);
        _sprintTimer = 0;
        Player.Animator.SetBool("IsSprinting", true);
    }

    public override void Exit()
    {
        base.Exit();
        Player.Animator.SetBool("IsSprinting", false);
    }

    public override void LogicUpdate()
    {
        if (_sprintTimer > Player.SprintTime)
        {
            SprintInput = false;
            Player.StateMachine.ChangeState(Player.States.WalkState);
        }
        else if (MoveInput == Vector3.zero)
        {
            SprintInput = false;
            Player.StateMachine.ChangeState(Player.States.IdleState);
        }
        else if (JumpInput && IsGrounded())
        {
            Player.StateMachine.ChangeState(Player.States.SprintJumpState);
        }

        _sprintTimer += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        PlayerMovement();
        PlayerRotation();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : BaseState
{
    private Player _player;

    public PlayerMoveState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entered MoveState");
    }

    public override void Exit()
    {
        Debug.Log("Exited MoveState");
    }

    public override void LogicUpdate()
    {
        PlayerInput();
    }

    public override void PhysicsUpdate()
    {
        PlayerMovement();
    }

    void PlayerInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        if (xInput == 0 && zInput == 0)
        {
            _player.ChangeState(_player.IdleState);
        }

        Vector3 relForward = _player.CamDir.forward * zInput;
        Vector3 relRight = _player.CamDir.right * xInput;

        relForward.y = 0;
        relRight.y = 0;
        
        _player.MoveDir = (relForward + relRight).normalized;

        if (_player.MoveDir.magnitude != 0 )
        {
            _player.transform.rotation = Quaternion.LookRotation(_player.MoveDir, Vector3.up);
        }
    }

    void PlayerMovement()
    {
        if (_player.Rb.velocity.magnitude < _player.TargetVelocity)
        {
            _player.Rb.AddForce(_player.MoveDir * _player.MoveForce, ForceMode.Acceleration);
        }
    }
}

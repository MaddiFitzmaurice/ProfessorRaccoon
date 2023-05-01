using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState
{
    private Player _player;

    public PlayerIdleState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entered IdleState");
    }

    public override void Exit()
    {
        Debug.Log("Exited IdleState");
    }

    public override void LogicUpdate()
    {
       PlayerInput();
    }

    public void PlayerInput()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            _player.ChangeState(_player.MoveState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.ChangeState(_player.JumpIdleState);
        }
    }
}

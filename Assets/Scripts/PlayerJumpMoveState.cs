using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpMoveState: BaseState
{
    private Player _player;

    public PlayerJumpMoveState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entered JumpMoveState");
    }

    public override void Exit()
    {
        Debug.Log("Exited JumpMoveState");
    }

    public override void LogicUpdate()
    {
        
    }
}

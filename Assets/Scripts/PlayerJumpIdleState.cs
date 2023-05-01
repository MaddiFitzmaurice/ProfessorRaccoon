using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpIdleState : BaseState
{
    private Player _player;

    public PlayerJumpIdleState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        Debug.Log("Entered JumpIdleState");
        Jump();
    }

    public override void Exit()
    {
        Debug.Log("Exited JumpIdleState");
    }

    public override void LogicUpdate()
    {
        if (Physics.Raycast(_player.transform.position, -_player.transform.up, out RaycastHit hit, 0.16f))
        {
            Debug.DrawRay(_player.transform.position, -_player.transform.up * 0.16f, Color.green);
            
            if (hit.collider.tag == "Ground" && _player.Rb.velocity.y < 0 )
            {
                _player.ChangeState(_player.IdleState);
            }
        }
        else
        {
            Debug.DrawRay(_player.transform.position, -_player.transform.up * 0.16f, Color.red);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }

    public void Jump()
    {
        Vector3 jumpArc = Vector3.up + (_player.transform.forward * 0.1f);
        _player.Rb.AddForce(jumpArc * _player.JumpIdleForce, ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintJumpState : PlayerBaseJumpState
{
    public PlayerSprintJumpState(Player player) : base(player) 
    {
    }

    public override void Enter()
    {
        Player.SetJumpHeight(Player.SprintJumpHeight);
        base.Enter();
        Debug.Log("Entered SprintJumpState");
    }

    protected override void Jump()
    {
        Vector3 jumpVector = MoveInput + Vector3.up;
        float jumpForce = Mathf.Sqrt(Player.JumpHeight * Physics.gravity.y * -2) * Player.Rb.mass;
        Player.Rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseJumpState
{
    public PlayerJumpState(Player player) : base(player) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered JumpState");
    }

    protected override void Jump()
    {
        Vector3 jumpVector = Vector3.up;
        float jumpForce = Mathf.Sqrt(Player.JumpHeight * Physics.gravity.y * -2) * Player.Rb.mass;
        Player.Rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
    }
}


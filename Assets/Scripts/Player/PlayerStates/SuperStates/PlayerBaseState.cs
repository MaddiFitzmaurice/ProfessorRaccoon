using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : BaseState
{
    protected Player Player;
    protected static Vector3 MoveInput;
    protected static bool JumpInput;
    protected static float CurrentSpeed;

    public PlayerBaseState(Player player)
    {
        Player = player;
        MoveInput = Vector3.zero;
        JumpInput = false;
    }

    public override void Enter()
    {
        InputChannel.MoveEvent += OnMove;
        InputChannel.JumpEvent += OnJump;
    }

    public override void Exit()
    {
        InputChannel.MoveEvent -= OnMove;
        InputChannel.JumpEvent -= OnJump;
    }

    // Receive inputs from InputManager
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        MoveInput.x = input.x;
        MoveInput.z = input.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }

    public void PlayerMovement()
    {
        // Calculate desired velocity
        float targetVelocity = MoveInput.magnitude * Player.MoveSpeed;

        // Find diff between desired velocity and current velocity
        float velocityDif = targetVelocity - Player.Rb.velocity.magnitude;

        // Check whether to accel or deccel
        float accelRate = (Mathf.Abs(targetVelocity) > 0.01f) ? Player.MoveAccel :
            Player.MoveDecel;

        // Calc force by multiplying accel and velocity diff, and applying velocity power
        float movement = Mathf.Pow(Mathf.Abs(velocityDif) * accelRate, Player.VelocityPower)
            * Mathf.Sign(velocityDif);

        Player.Rb.AddForce(movement * MoveInput);
    }

    //public bool IsGrounded()
    //{
    //return Physics.BoxCast(Player.LionBodyRefCollider.gameObject.transform.position, Player.GroundCheckCollider.bounds.extents * 2, Vector3.down,
    //out RaycastHit hit, Player.transform.rotation, 0.7f, LayerMask.GetMask("Walkable"));)
    //}
}

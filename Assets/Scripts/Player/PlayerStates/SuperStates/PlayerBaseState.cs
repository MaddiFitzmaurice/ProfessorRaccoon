using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

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
        CalculateMoveVector(context.ReadValue<Vector2>());
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

    public void CalculateMoveVector(Vector2 input)
    {
        Vector3 camVectorRight = Player.Cam.transform.right;
        Vector3 camVectorForward = Player.Cam.transform.forward;

        camVectorForward.y = 0;
        camVectorRight.y = 0;

        Vector3 relRight = camVectorRight.normalized * input.x;
        Vector3 relForward = camVectorForward.normalized * input.y;
        MoveInput = (relRight + relForward).normalized;
        MoveInput.y = 0;
        Debug.Log(MoveInput);
    }

    // Movement
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

    public void PlayerRotation()
    {
        if (MoveInput.magnitude != 0)
        {
            Player.transform.rotation = Quaternion.LookRotation(MoveInput, Vector3.up);
        }
    }

    //public bool IsGrounded()
    //{
    //return Physics.BoxCast(Player.LionBodyRefCollider.gameObject.transform.position, Player.GroundCheckCollider.bounds.extents * 2, Vector3.down,
    //out RaycastHit hit, Player.transform.rotation, 0.7f, LayerMask.GetMask("Walkable"));)
    //}
}

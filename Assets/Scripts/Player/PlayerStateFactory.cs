using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
    // Player Move States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerSprintState SprintState { get; private set; }

    // Player Air States
    public PlayerJumpState JumpState { get; private set; }
    public PlayerSprintJumpState SprintJumpState { get; private set; }
    public PlayerFallState FallState { get; private set; } 

    public PlayerStateFactory(Player player)
    {
        IdleState = new PlayerIdleState(player);
        WalkState = new PlayerWalkState(player); 
        SprintState = new PlayerSprintState(player);
        JumpState = new PlayerJumpState(player);
        SprintJumpState = new PlayerSprintJumpState(player);
        FallState = new PlayerFallState(player);   
    }
}

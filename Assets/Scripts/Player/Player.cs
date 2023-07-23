using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // State Machine + States
    public StateMachine StateMachine { get; private set; }
    public PlayerStateFactory States { get; private set; }

    // Components
    public Rigidbody Rb { get; private set; }
    [field:Header("Components")]
    [field:SerializeField] public Camera Cam { get; private set; }
    [field:SerializeField] public BoxCollider GroundCheckCol { get; private set; }
    [field:SerializeField] public Animator Animator { get; private set; }

    // Data
    [field:Header("Movement Data")]
    [field:SerializeField] public PlayerData WalkData { get; private set; }
    [field:SerializeField] public PlayerData SprintData { get; private set; }
    [field:SerializeField] public PlayerData InAirData { get; private set; }

    // Base data to change based on state
    public float MoveSpeed { get; private set; }
    public float MoveAccel { get; private set; }
    public float MoveDecel { get; private set; }
    public float VelocityPower { get; private set; }
    public float JumpHeight { get; private set; }

    [field:Header("Additional Data")]
    [field:SerializeField] public float SprintTime { get; private set; }
    [field:SerializeField] public float WalkJumpHeight { get; private set; }
    [field: SerializeField] public float SprintJumpHeight { get; private set; }

    void Awake()
    {
        ComponentSetup();
        StateMachineSetup();
    }

    public void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    void StateMachineSetup()
    {
        States = new PlayerStateFactory(this);
        StateMachine = new StateMachine(States.IdleState);
    }

    void ComponentSetup()
    {
        Rb = GetComponent<Rigidbody>();
    }

    public void DataChange(PlayerData data)
    {
        MoveSpeed = data.MoveSpeed;
        MoveAccel = data.MoveAccel;
        MoveDecel = data.MoveDecel;
        VelocityPower = data.VelocityPower;
    }

    public void SetJumpHeight(float height)
    {
        JumpHeight = height;
    }
}

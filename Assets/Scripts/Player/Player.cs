using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // State Machine + States
    public StateMachine StateMachine { get; private set; }
    public PlayerStateFactory States { get; private set; }
    
    void Awake()
    {
        StateMachineSetup();
    }

    void StateMachineSetup()
    {
        States = new PlayerStateFactory(this);
        StateMachine = new StateMachine(States.IdleState);
    }
}

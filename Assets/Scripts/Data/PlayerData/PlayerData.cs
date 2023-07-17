using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 1)]
#endif

public class PlayerData : ScriptableObject
{
    public float MoveSpeed;
    public float MoveAccel;
    public float MoveDecel;
    public float VelocityPower;
    public float JumpHeight;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : BaseState
{
    protected Player Player;

    public PlayerBaseState(Player player)
    {
        Player = player;
    }
}

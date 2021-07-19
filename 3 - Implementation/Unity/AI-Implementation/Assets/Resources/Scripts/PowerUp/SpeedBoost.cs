﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
    [SerializeField] protected float multiplier;
    public override void OnAgentEnter(Agent agent)
    {
        agent.MoveTime *= multiplier;
    }
}

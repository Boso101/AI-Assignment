using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
    [SerializeField] protected float divisor;
    public override void OnAgentEnter(Agent agent)
    {
        agent.MoveTime /= divisor;
        if(agent.MoveTime <= 0.25f)
        {
            agent.MoveTime = 0.25f;
        }
        Destroy(gameObject);
    }
}

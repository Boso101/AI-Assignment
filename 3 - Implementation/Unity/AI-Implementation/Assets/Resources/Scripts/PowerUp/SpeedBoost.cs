using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
    [SerializeField] protected float divisor;
    public override void OnAgentEnter(Agent agent)
    {
        agent.MoveTime /= divisor;
        if(agent.MoveTime < 0)
        {
            agent.MoveTime = 0;
        }
        Destroy(gameObject);
    }
}

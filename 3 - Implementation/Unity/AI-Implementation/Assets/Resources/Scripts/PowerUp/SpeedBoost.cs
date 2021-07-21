using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
    [SerializeField] protected float divisor;
    public override void OnAgentEnter(Agent agent)
    {
        agent.MoveTime /= divisor;
        if(agent.MoveTime < 0.15f)
        {
            agent.MoveTime = 0.15f;
        }
        else
        {
            Destroy(gameObject);

        }
    }
}

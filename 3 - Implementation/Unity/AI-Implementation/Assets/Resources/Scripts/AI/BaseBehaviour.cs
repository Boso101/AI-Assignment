using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    protected Agent agent;
    public Agent Agent { get => agent;  }
    public void TryMoveTo(PathNode node)
    {
        agent.SetDestination(node);
    }

    public void Die()
    {
        agent.Remove();
    }
}

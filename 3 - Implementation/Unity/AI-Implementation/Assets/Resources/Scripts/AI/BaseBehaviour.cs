using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    protected static Grid level;

    protected Agent agent;
    public Agent Agent { get => agent;  }

    public virtual void AwakeFunction()
    {
        if (level == null) level = GameObject.FindObjectOfType<Game>().Grid;
        agent = GetComponent<Agent>();
    }

    private void Awake()
    {
        AwakeFunction();
    }

    public void TryMoveTo(PathNode node)
    {
        agent.SetDestination(node);
    }

  

    
}

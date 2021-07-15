using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    protected static Grid level;

    protected Agent agent;
    public Agent Agent { get => agent;  }


    private void Awake()
    {
        if(level == null) level = GameObject.FindObjectOfType<Game>().Grid;
        agent = GetComponent<Agent>();
    }
    public void TryMoveTo(PathNode node)
    {
        agent.SetDestination(node);
    }

    public void Die()
    {
        agent.Remove();
    }

    
}

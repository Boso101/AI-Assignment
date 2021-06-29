using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    protected List<Behaviour> behaviourList;


    public void AddBehaviour(Behaviour behaviour)
    {
        behaviourList.Add(behaviour);
    }

    public void RemoveBehaviour(Behaviour behaviour)
    {
        behaviourList.Remove(behaviour);
    }

    public void RemoveBehaviour(int index)
    {
        behaviourList.RemoveAt(index);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behaviour
{
    public Behaviour()
    {

    }

    public abstract bool Update(Agent agent, float deltaTime);
 
}

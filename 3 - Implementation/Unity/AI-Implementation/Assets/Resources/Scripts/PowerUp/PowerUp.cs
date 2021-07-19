using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract void OnAgentEnter(Agent agent);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Agent>(out Agent agent))
        {
            OnAgentEnter(agent);
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract void OnAgentEnter(Agent agent);
  



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Agent>(out Agent agent))
        {
            OnAgentEnter(agent);
        }
    }
}

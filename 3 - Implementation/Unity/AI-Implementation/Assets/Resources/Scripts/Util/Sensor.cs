using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] protected float senseRadius;
    [SerializeField] protected LayerMask detecting;
    [SerializeField] protected float detectInterval;

    protected GameObject target;



    public GameObject Target { get => target; }
    public void Detect()
    {
        // Circle Raycast and go after player
       Collider2D[] potentialTargs =  Physics2D.OverlapCircleAll(transform.position, senseRadius);

        //check for player
        foreach (Collider2D coll in potentialTargs)
        {
            if (coll.gameObject.tag == "Player")
            {
                SetTarget(coll.gameObject);
            }

        }
    }


    // Debug
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, senseRadius);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}

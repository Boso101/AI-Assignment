using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    [SerializeField] protected float senseRadius;
    [SerializeField] protected LayerMask detecting;
    [SerializeField] protected float detectInterval;

    protected GameObject target;
    protected Vector2 lastKnownPosition;

    public UnityEvent OnSeePlayer;

    private void Start()
    {
        InvokeRepeating(nameof(Detect), 1, detectInterval);
    }

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
                OnSeePlayer?.Invoke();
                return;
            }

        }

        SetTarget(null);
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

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        if (target)
        {
            lastKnownPosition = target.transform.position;
        }
    }
}

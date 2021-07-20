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

    [Header("Tag Priority")]
    public List<string> hates; // PlayerTag
    public List<string> likes; // Powerup
    public List<string> scared; //Zombie

    private void Start()
    {
        InvokeRepeating(nameof(Detect), 1, detectInterval);
    }

    public GameObject Target { get => target; }
    public Vector2 LastPosition { get => lastKnownPosition; }
    public void Detect()
    {
        // Circle Raycast and go after player
       Collider2D[] potentialTargs =  Physics2D.OverlapCircleAll(transform.position, senseRadius);

        //check for player
        foreach (Collider2D coll in potentialTargs)
        {
            string foundTag = coll.gameObject.tag;

            //Check if we found something that we either hate like or scared of
            if((coll.gameObject != gameObject) && hates.Contains(foundTag) || likes.Contains(foundTag) || scared.Contains(foundTag))
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

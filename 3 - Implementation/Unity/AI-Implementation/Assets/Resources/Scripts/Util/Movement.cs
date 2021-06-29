using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected Vector2 velocity;
    protected Vector2 force;





    public Vector2 GetVelocity()
    {
        return velocity;
    }

    public void SetVelocity(Vector2 vel)
    {
        velocity = vel;
    }

    public Vector2 GetForce()
    {
        return force;
    }

    public void SetForce(Vector2 force)
    {
        this.force = force;
    }
}

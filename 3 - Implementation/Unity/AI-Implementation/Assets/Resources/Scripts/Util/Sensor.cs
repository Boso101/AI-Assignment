﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] protected float senseRadius;
    [SerializeField] protected LayerMask detecting;
    [SerializeField] protected float detectInterval;

    protected GameObject target;




    public void Detect()
    {
        // Circle Raycast and go after player
    }



}

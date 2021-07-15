using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : BaseBehaviour
{
    protected Sensor sensor;

    private void Start()
    {
        sensor = GetComponent<Sensor>();
    }
    public void GoToTarget()
    {
        if(sensor != null && sensor.Target != null)
        {
            Vector2 enemyPos = sensor.Target.transform.position;
            TryMoveTo(level.GetNode((int)enemyPos.x, (int)enemyPos.y));

        }
        else
        {
            // Go to last known pos
            Vector2 lastPos = sensor.LastPosition;
            TryMoveTo(level.GetNode((int)lastPos.x, (int)lastPos.y));
        }
    }
    private void Update()
    {
        if (sensor.Target == null)
        {
            
        }
    }
}

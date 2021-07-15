using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : BaseBehaviour
{
    protected Sensor sensor;


public void GoToTarget()
    {
        if(sensor.Target)
        {
            Vector2 enemyPos = sensor.Target.transform.position;
            TryMoveTo(level.GetNode((int)enemyPos.x, (int)enemyPos.y));

        }
    }
}

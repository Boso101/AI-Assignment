using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : BaseBehaviour
{
    protected static List<ChaserBehaviour> chaserEntitys;

    protected Sensor sensor;

    private void OnDestroy()
    {
        Remove();
    }

    private void OnDisable()
    {
        Remove();
    }

    private void Awake()
    {
        sensor = GetComponent<Sensor>();
        if (chaserEntitys == null) chaserEntitys = new List<ChaserBehaviour>();
        chaserEntitys.Add(this);

    }
    public void GoToTarget()
    {
        if (sensor != null && sensor.Target != null)
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



    public void Remove()
    {
        chaserEntitys.Remove(this);
        Destroy(gameObject);
    }

    public void TellOthersAboutTarget()
    {
    if(sensor.Target != null && sensor.Target.CompareTag("Player"))
        {

        Vector2 enemyPos = sensor.Target.transform.position;

        foreach (ChaserBehaviour chaser in chaserEntitys)
        {
            if(chaser == this)
            {
                continue;
            }
            //Get them to move in about the right area
            chaser.TryMoveTo(level.GetNode((int)enemyPos.x, (int)enemyPos.y));
            
        }
        }

    }

   

}

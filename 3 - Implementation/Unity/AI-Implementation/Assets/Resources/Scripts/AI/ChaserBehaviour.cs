using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : BaseBehaviour
{
    public const int MAX_CHASERS_AT_TIME = 150;

    protected static List<ChaserBehaviour> chaserEntitys;

    protected Sensor sensor;

    public bool canBlackBoard = true; // Can this chaser listen to other chasers?

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
        AwakeFunction();
        Debug.Log("Chasers: " + chaserEntitys.Count);

    }

    public override void AwakeFunction()
    {
        base.AwakeFunction();
        sensor = GetComponent<Sensor>();
        if (chaserEntitys == null) chaserEntitys = new List<ChaserBehaviour>();
        chaserEntitys.Add(this);
    }
    public void GoToTarget()
    {
        PathNode pathNode;
        if (sensor != null && sensor.Target != null)
        {
            Vector2 enemyPos = sensor.Target.transform.position;
            pathNode = level.GetNode((int)enemyPos.x, (int)enemyPos.y);

  

        }
        else
        {
            // Go to last known pos
            Vector2 lastPos = sensor.LastPosition;
            pathNode = level.GetNode((int)lastPos.x, (int)lastPos.y);

           
        }


        if (pathNode != null)
            TryMoveTo(pathNode);
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
            if (chaserEntitys.Count <= MAX_CHASERS_AT_TIME)
            {
                foreach (ChaserBehaviour chaser in chaserEntitys)
                {
                    if (chaser == this)
                    {
                        continue;
                    }

                    if (chaser.canBlackBoard)
                        //Get them to move in about the right area
                        chaser.TryMoveTo(level.GetNode((int)enemyPos.x, (int)enemyPos.y));

                }
            }
            else
            {

                //Only order 26
                for (int i = 0; i < MAX_CHASERS_AT_TIME; i++)
                {
                    if(chaserEntitys[i].canBlackBoard)
                    {
                        chaserEntitys[i].TryMoveTo(level.GetNode((int)enemyPos.x, (int)enemyPos.y));
                    }
                }

            }
        
        }

    }

   

}

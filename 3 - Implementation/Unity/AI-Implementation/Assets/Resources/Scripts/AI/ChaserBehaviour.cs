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
    /// <summary>
    /// This refers to target Position, not necesarilly the object we are looking at as our target
    /// </summary>
    public void GoToTarget()
    {
        PathNode pathNode;
        if (sensor != null && sensor.Target != null)
        {
            string objTag = sensor.Target.tag;
            // We like or hate so go to it
            if (sensor.likes.Contains(objTag) || sensor.hates.Contains(objTag))
            {
                Vector2 enemyPos = sensor.Target.transform.position;
                pathNode = level.GetNode((int)enemyPos.x, (int)enemyPos.y);



            }
            //We scared of it so try run away
            else if (sensor.scared.Contains(objTag))
            {
                Vector2 enemyPos = sensor.Target.transform.position;


                do
                {

                    pathNode = level.RandomSpot(transform.position, 42f);
                }

                //TOOD: Real flee please
                while ((pathNode == null));


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
    }



    public void Remove()
    {
        chaserEntitys.Remove(this);
        Destroy(gameObject);
    }

    public void TellOthersAboutTarget()
    {
        //Make sure we got a target and that target is the player
        if (sensor.Target != null && sensor.Target.CompareTag("Player"))
        {
            //store targPos
            Vector2 enemyPos = sensor.Target.transform.position;

            //Determine what to do based on how many chasers are spawned
            //If too many are spawned, then don't blackboard all of them

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

                //Only order the max amount
                for (int i = 0; i < MAX_CHASERS_AT_TIME; i++)
                {
                    if (chaserEntitys[i].canBlackBoard)
                    {
                        chaserEntitys[i].TryMoveTo(level.GetNode((int)enemyPos.x, (int)enemyPos.y));
                    }
                }

            }

        }

    }



}

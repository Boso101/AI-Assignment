using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public static List<Agent> currentAgents;

   
    public static Astar pathFinding;

    // How many units do this move per move update
    [SerializeField] protected int unitsPerMove = 1;
    [SerializeField] protected int moveTime = 1; // Time in seconds before this agent can move to another tile

    //path container
    protected PathContainer container;
    

    public IEnumerator Move(Vector2 newPos)
    {
        yield return new WaitForSeconds(moveTime);
        transform.position = newPos;
    }

    private  void CalculateMovement()
    {
    }

    private void Start()
    {
        container = new PathContainer();

        //TODO: Maybe just dont have an instance of pathfinding for each agent.
        if(pathFinding == null) pathFinding = new Astar();
        if (currentAgents == null) currentAgents = new List<Agent>();


        currentAgents.Add(this);
    }
    private void Update()
    {
        
    }
}

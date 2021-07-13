using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    protected static List<Agent> currentAgents;
    protected static Astar pathFinding;
    protected static Grid game;

    // How many units do this move per move update
    [SerializeField] protected int unitsPerMove = 1;
    [SerializeField] protected int moveTime = 1; // Time in seconds before this agent can move to another tile

    // Costs for movement
    [SerializeField] protected int straightCost = 14;
    [SerializeField] protected int diagonalCost = 10;

    //path container
    protected PathContainer container;
    protected AgentState state;

    protected Vector2 targetPosition;

   

    private void Start()
    {
        container = new PathContainer();

        //TODO: Maybe just dont have an instance of pathfinding for each agent.
        if(pathFinding == null) pathFinding = new Astar();
        if (currentAgents == null) currentAgents = new List<Agent>();
        if (game == null) game = GameObject.FindObjectOfType<Game>().Grid;


        currentAgents.Add(this);
    }
    private void Update()
    {
        switch (state)
        {
            case AgentState.IDLE:
                break;
            case AgentState.PATROL:
                break;
            case AgentState.CHASE:
                TryMove();
                break;

        }
    }

    private IEnumerator Move(Vector2 newPos)
    {
        yield return new WaitForSeconds(moveTime);
        transform.position = newPos;
    }

    /// <summary>
    /// Uses A* to get the path 
    /// </summary>
    public void CalculateMovement(Vector2 targetLocation)
    {
        //Call the Find Path function which wil set the path within the container variable
        pathFinding.FindPath(game, container, (int)transform.position.x, (int)transform.position.y, (int)targetLocation.x, (int)targetLocation.y, straightCost, diagonalCost);
    }

    private void TryMove()
    {
        if(container.Path != null)
        StartCoroutine(Move(container.GetNextNode().GetPosition()));
    }

    public void Remove()
    {
        currentAgents.Remove(this);
        Destroy(gameObject);
    }
}

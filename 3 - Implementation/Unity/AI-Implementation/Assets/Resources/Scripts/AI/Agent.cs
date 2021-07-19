using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    protected static Astar pathFinding;
    protected static Grid game;

    // How many units do this move per move update
    [SerializeField] protected int unitsPerMove = 1;
    [SerializeField] protected float moveTime = 1; // Time in seconds before this agent can move to another tile
    [SerializeField] protected float patrolDistance = 4f;
    protected float timeUntilNextMove;

    // Costs for movement
    [SerializeField] protected int straightCost = 14;
    [SerializeField] protected int diagonalCost = 10;

    //path container
    protected PathContainer container;
   [SerializeField] protected AgentState state;

    protected Vector2 targetPosition;
    protected bool canMove;

   public float MoveTime { get => moveTime; set => moveTime = value; }
   public int StraightCost { get => straightCost; set => straightCost = value; }
    public int DiagonalCost { get => diagonalCost; set => diagonalCost = value; }


    private void Start()
    {
        container = new PathContainer();

        //TODO: Maybe just dont have an instance of pathfinding for each agent.
        if(pathFinding == null) pathFinding = new Astar();
     
        if (game == null) game = GameObject.FindObjectOfType<Game>().Grid;
        timeUntilNextMove = moveTime;

    }
    private void Update()
    {
        timeUntilNextMove -= Time.deltaTime;
        switch (state)
        {
            case AgentState.IDLE:

                //Not good but whatever
                if (!CompareTag("Player") && targetPosition == (Vector2)transform.position)
                {
                    SetState(AgentState.PATROL);
                }
                break;
            case AgentState.PATROL:
                Patrol();
                
               
                break;
            case AgentState.CHASE:
                TryMove();
                break;

        }
 
    }

    public bool ReachedDestination()
    {
        return (Vector2)transform.position == targetPosition;
    }

    private void Move(Vector2 newPos)
    {
        
            transform.position = newPos;
            timeUntilNextMove = moveTime;
    }
      

    /// <summary>
    /// Uses A* to get the path 
    /// </summary>
    private void CalculatePath(PathNode node)
    {
        //Call the Find Path function which wil set the path within the container variable
        if(node != null)
        {

        pathFinding.FindPath(game, container, (int)transform.position.x, (int)transform.position.y, node.GetXPosition(), node.GetYPosition(), straightCost, diagonalCost);
        if (container.Path != null && container.ViewLastNode() != null) 
            targetPosition = container.ViewLastNode().GetPosition();
        else
        {
            return;
        }

        }

    }

    public void SetDestination(PathNode node)
    {
        CalculatePath(node);
        SetState(AgentState.CHASE);

    }

    public void Patrol()
    {
       SetDestination(game.RandomSpot(transform.position, patrolDistance));
        
    }
    private void TryMove()
    {
     
        PathNode nextNode = container.ViewNextNode();

        if (nextNode != null)
        {

            //is it time to move again
            if (timeUntilNextMove <= 0)
            {
                // Begin moving
                Move(nextNode.GetPosition());
                container.Next();
            }
            else
            {
                return;
            }
        }
        else
        {
            SetState(AgentState.IDLE);
        }

    }

    public void SetState(AgentState st)
    {
        state = st;
    }

    
  
}

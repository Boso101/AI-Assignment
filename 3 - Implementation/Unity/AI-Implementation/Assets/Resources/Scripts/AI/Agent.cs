using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public static Vector2 playerPosition;
    public static Astar pathFinding;
    protected Vector2 targetLocation;

    // How many units do this move per move update
    [SerializeField] protected int unitsPerMove = 1;

    //path container
    protected PathContainer container;
    

    public void Move(Vector2 newPos)
    {
        transform.position = newPos;
    }

    private Vector2 CalculateMovement()
    {
        return Vector2.zero;
    }

    private void Start()
    {
        container = new PathContainer();

        //TODO: Maybe just dont have an instance of pathfinding for each agent.
        if(pathFinding == null) pathFinding = new Astar();
    }
    private void Update()
    {
        
    }
}
